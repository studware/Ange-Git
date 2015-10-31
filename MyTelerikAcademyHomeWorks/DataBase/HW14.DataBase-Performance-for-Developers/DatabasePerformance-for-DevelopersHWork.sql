-- T1. Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).                               

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

CREATE TABLE Articles(
	ArticleId int NOT NULL PRIMARY KEY IDENTITY,
	ArticleName varchar(100),
	IssueDate date
)
GO

--	Please be patient, this is a delay in order to update the PK__Articles__....... after new table creation
WAITFOR DELAY '00:02:00';
GO

INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article1', GETDATE())
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article2', GETDATE() + 1)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article3', GETDATE() + 2)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article4', GETDATE() + 3)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article5', GETDATE() + 4)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article6', GETDATE() + 5)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article7', GETDATE() + 6)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article8', GETDATE() + 7)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article9', GETDATE() + 8)
INSERT INTO Articles(ArticleName, IssueDate) VALUES ('Article10', GETDATE() + 9)
GO

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Articles) < 10000000
BEGIN
	INSERT INTO Articles(ArticleName, IssueDate)
	SELECT ArticleName + CONVERT(varchar, @Counter), GETDATE() + @Counter FROM Articles
	SET @Counter = @Counter + 1
END
GO

-- Elapsed Time: 00:01:06
-- HomeworkDB.mdf: 522 MB
-- HomeworkDB_log.ldf: 1.30 GB


-- T2. Add an index to speed-up the search by date. Test the search speed (after 
-- cleaning the cache).                               

CREATE INDEX IDX_Articles_IssueDate
ON Articles(IssueDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Articles
WHERE IssueDate BETWEEN GETDATE() AND GETDATE() + 15

-- Elapsed Time: 00:00:05

-- T3. Add a full text index for the text column. Try to search with and without 
-- the full-text index and compare the speed.                              

-- Creating full-text catalog and full-text index
CREATE FULLTEXT CATALOG ArticleNameFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Articles(ArticleName)
KEY INDEX PK__Articles__9C6270E8954FBC95
ON ArticleNameFullTextCatalog
WITH CHANGE_TRACKING AUTO


-- Searching without full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Articles
WHERE ArticleName LIKE 'Article2%'
GO

-- Elapsed Time: 00:00:07

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Articles
WHERE ArticleName LIKE 'Article4%'
GO

-- Elapsed Time: 00:00:10

-- Searching with full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Articles
WHERE CONTAINS(ArticleName, 'Article1')
GO

-- Elapsed Time: 00:00:07

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Articles
WHERE CONTAINS(ArticleName, 'Article8')
GO

-- Elapsed Time: 00:00:07

-- T4. Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random 
-- dates) to certain partition (e.g. year 1995).                           

-- Without partitioning
CREATE SCHEMA `articles`;

CREATE TABLE `articles`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`ArticleName` TEXT NOT NULL,
	`IssueDate` DATETIME NOT NULL,
	PRIMARY KEY (`Id`));

-- With partitioning
CREATE SCHEMA `articles`;

CREATE TABLE `articles`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`ArticleName` TEXT NOT NULL,
	`IssueDate` DATETIME NOT NULL,
	PRIMARY KEY (`Id`, `IssueDate`)
) PARTITION BY RANGE(YEAR(IssueDate)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

-- EXPLAIN PARTITIONS SELECT * FROM Logs;