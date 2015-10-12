
USE TelerikAcademy
GO
--01 Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--  Use a nested SELECT statement.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)

--02 Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
DECLARE @minSalary money
SET @minSalary = (SELECT MIN(Salary) FROM Employees)
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN @minSalary AND 1.1*@minSalary
ORDER BY Salary

--03 Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
	-- Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary, d.Name AS [Department Name]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary)	FROM Employees
	WHERE DepartmentID = e.DepartmentID)
ORDER BY Salary

--04 Write a SQL query to find the average salary in the department #1
SELECT ROUND(AVG(Salary),2) AS [4.AVG Salary Dept.1]
FROM Employees
WHERE DepartmentID = 1

--05 Write a SQL query to find the average salary in the "Sales" department
SELECT ROUND(AVG(Salary),2) AS [5.AVG Salary Sales Dept.]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--06 Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID) AS [6.Count of Employees Sales Dept.]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--07  Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(EmployeeID) AS [7.Count of Employees with Manager]
FROM Employees
WHERE ManagerID IS NOT NULL

SELECT COUNT(EmployeeID) AS [7.Count of Employees with Manager using EXISTS]
FROM Employees e
WHERE EXISTS 
	(SELECT EmployeeID
	FROM Employees m
	WHERE m.EmployeeID = e.ManagerID)

--08 Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(EmployeeID) AS [8.Count of Employees without Manager]
FROM Employees
WHERE ManagerID IS NULL

SELECT COUNT(EmployeeID) AS [8.Count of Employees without Manager using NOT EXISTS]
FROM Employees e
WHERE NOT EXISTS 
	(SELECT EmployeeID
	FROM Employees m
	WHERE m.EmployeeID = e.ManagerID)

--09 Write a SQL query to find all departments and the average salary for each of them.
SELECT ROUND(AVG(Salary),2) AS [9.AVG Salary for ALL Departments]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID

--10 Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name  AS [Town Name], d.Name AS [Department Name], 
		COUNT(e.EmployeeID) AS [Empl.Count by Dept and Town] 
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY t.Name, d.Name

--11 Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.ManagerID, e.FirstName+' '+e.LastName AS [Manager Name], COUNT(m.ManagerID) AS [Count of Employees]
  FROM Employees e JOIN Employees m
  ON e.EmployeeID = m.ManagerID
  GROUP BY m.ManagerID, e.FirstName, e.LastName
  HAVING COUNT(m.ManagerID)=5
  ORDER BY m.ManagerID
  
--12 Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)"
SELECT e.EmployeeID, e.FirstName + ' ' + e.LastName AS [Employee Name],
	   ISNULL(emp.FirstName + ' '+ emp.LastName, 'no manager') AS [Manager Name]
	FROM Employees e
	LEFT JOIN Employees emp
		ON e.ManagerID = emp.EmployeeID

--13  Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName + ' ' + LastName AS [13.Employes with 5-Chars Last Name]
FROM Employees
WHERE LEN(LastName)=5

--14 Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
    --Search in Google to find how to format dates in SQL Server.
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff') AS [14.Date and Time Local Format]

--15 Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
    --Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
    --Define the primary key column as identity to facilitate inserting records.
    --Define unique constraint to avoid repeating usernames.
    --Define a check constraint to ensure the password is at least 5 characters long.

if NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')
	CREATE TABLE Users (
		UserID int IDENTITY PRIMARY KEY,
		UserName nvarchar(50) NOT NULL UNIQUE,
		[Password] nvarchar(50) NULL CHECK(LEN([Password])>5),
		[Full Name] nvarchar(25) NOT NULL,
		[LastLogin Time] datetime NULL
	)
GO

--16 Write a SQL statement to create a view that displays the users from the Users table
--that have been in the system today.
	 -- Test if the view works correctly.
-- NOT EXISTS (SELECT * FROM sysobjects WHERE name='Logged Today' and xtype='V') 
CREATE VIEW [Logged Today] AS
SELECT Username, [LastLogin Time]
FROM Users
WHERE
CONVERT(VARCHAR(10), [LastLogin Time], 102) <= CONVERT(VARCHAR(10) ,GETDATE(), 102)

GO

--17 Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
	-- Define primary key and identity column.
if NOT EXISTS (SELECT * FROM sysobjects WHERE name='Groups' and xtype='U')
	CREATE TABLE Groups(
		GroupId int IDENTITY PRIMARY KEY,
		Name nvarchar(50) NOT NULL UNIQUE
	)
GO

--18 Write a SQL statement to add a column GroupID to the table Users.
	--Fill some data in this new column and as well in the `Groups table.
    --Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
	ADD GroupID int
GO
ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupId)
	REFERENCES Groups(GroupId)
GO

--19 Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups (Name)
VALUES
    ('DbDesign'),
    ('WebDesign'),
    ('SEO'),
    ('Ninja'),
    ('World');

INSERT INTO Users (UserName, [Password], [Full Name], [LastLogin Time], GroupID)
VALUES
    ('user12', 'q5tgc5', 'name surname 10', '1995-9-06 00:00:00', 3),
    ('user11', ' wr ts234', 'name surname 11', '2010-12-07 00:00:00', 1),
    ('user14', ' 5ghngmf', 'name surname 12', '2010-2-08 00:00:00', 5),
    ('user1', ' htghm3453', 'name surname 13', '2015-3-09 00:00:00', 2),
    ('user16', 'cvvfg4356', 'name surname 14', '2001-8-10 00:00:00', 4),
    ('user7', 'rt5rtr098', 'name surname 15', '2007-10-11 00:00:00', 3),
    ('user18', '4rf890oiki', 'name surname 16', '1989-10-12 00:00:00', 5),
    ('user9', 'refftg8iuol', 'name surname 18', '2009-7-13 00:00:00', 1),
    ('user2', 'rerttrguiku', 'name surname 19', '2015-9-14 00:00:00', 4);

--20 Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
	SET Username = REPLACE(UserName, 'user18', 'userEighteen')

UPDATE Users
SET [LastLogin Time]= GETDATE()
WHERE UserId % 2 = 0

UPDATE Groups
SET Name = 'analytics'
WHERE GroupId = 4 

--21 Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE UserName = 'userEighteen'

DELETE FROM Groups
WHERE GroupId = 10

--22 Write SQL statements to insert in the Users table the names of all employees from the Employees table.
    --Combine the first and last names as a full name.
    --For username use the first letter of the first name + the last name (in lowercase).
    --Use the same for the password, and NULL for last login time.

INSERT INTO Users (UserName, [Password], [Full Name])
    SELECT CONCAT(LEFT(FirstName,1), '.', LOWER(LastName)),
           LEFT(FirstName,1) + LOWER(RIGHT(LastName,5)),
            LOWER(CONCAT(FirstName, ' ', LastName))
    FROM Employees
GO

--23 Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
    SET [Password] = NULL
    WHERE DATEDIFF(day, [LastLogin Time], '2010-3-10 00:00:00') > 0
    
-- 24 Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
    WHERE [Password] IS NULL
    
-- 25 Write a SQL query to display the average employee salary by department and job title.
SELECT ROUND(AVG(e.Salary), 2) AS [Average Employee Salary], 
        d.Name AS [Department], 
        e.JobTitle
    FROM Employees e 
    JOIN Departments d
        ON e.DepartmentID = d.DepartmentID
    GROUP BY d.Name, e.JobTitle
    ORDER BY d.Name
    
-- 26 Write a SQL query to display the minimal employee salary by department and job title 
-- along with the name of some of the employees that take it.

SELECT ROUND(MIN(e.Salary), 2) AS [MinSalary], 
        d.Name AS [Department],
        e.JobTitle, 
        MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS [First Employee by Name],
        MAX(CONCAT(e.FirstName, ' ', e.LastName)) AS [Last Employee by Name]
    FROM Employees e 
    JOIN Departments d
        ON e.DepartmentID = d.DepartmentID
    GROUP BY d.Name, e.JobTitle
    ORDER BY d.Name

-- 27 Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name AS [27.Town], COUNT(e.EmployeeID) as [EmployeesCount]
    FROM Employees e 
    JOIN Addresses a
        ON e.AddressID = a.AddressID
    JOIN Towns t
        ON t.TownID = a.TownID
    GROUP BY t.Name
    ORDER BY EmployeesCount DESC

-- 28 Write a SQL query to display the number of managers from each town.
SELECT t.Name AS [28.Town], COUNT(DISTINCT e.ManagerID) AS [Managers Count]
    FROM Employees e 
    JOIN Addresses a
        ON e.AddressID = a.AddressID
    JOIN Towns t
        ON t.TownID = a.TownID
    GROUP BY t.Name
    ORDER BY [Managers Count] DESC

-- 29 Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--	  Don't forget to define identity, primary key and appropriate foreign key.
--	  Issue few SQL statements to insert, update and delete of some data in the table.
--	  Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--	  For each change keep the old record data, the new record data and the command (insert / update / delete).

if NOT EXISTS (SELECT * FROM sysobjects WHERE name='WorkHours' and xtype='U')

CREATE TABLE WorkHours(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT NOT NULL,
DateOfReport DATETIME,
Task NVARCHAR(50),
HoursOfWork INT,
Comments NVARCHAR(500),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeID)
)


--Add some records--
DECLARE @counter int
SET @counter=0

WHILE @counter<30
BEGIN
INSERT INTO WorkHours(EmployeeId,DateOfReport,Task,HoursOfWork,Comments)
VALUES (@counter,GETDATE(),'task'+CONVERT(VARCHAR(5), @counter),8,'comment'+CONVERT(VARCHAR(5), @counter))
SET @counter=@counter +1
END
DROP TABLE WorkHoursLog
GO

--WorkLogs--
CREATE TABLE WorkHoursLog(
Id int PRIMARY KEY IDENTITY(1,1),
WorkHoursId int,
EmployeeId INT FOREIGN KEY REFERENCES Employees(EmployeeId),
DateOfReport DATETIME,
Task NVARCHAR(50),
HoursOfWork INT,
Comments NVARCHAR(500),
[Action] varchar(10) NOT NULL
)

-- triggers --

--INSERT--
DROP TRIGGER trg_WorkHours_Insert
GO
CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
FOR INSERT 
AS
INSERT INTO WorkHoursLog(WorkHoursId, EmployeeId, DateOfReport, Task, HoursOfWork, Comments, [Action])
    SELECT Id, EmployeeID, DateOfReport, Task, HoursOfWork, Comments, 'Insert'
    FROM inserted
PRINT 'FOR INSERT trigger fired.'
GO

--DELTETE--
DROP TRIGGER trg_WorkHours_Delete
GO
CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
FOR DELETE 
AS
INSERT INTO WorkHoursLog(WorkHoursId,EmployeeId, DateOfReport, Task, HoursOfWork, Comments, [Action])
    SELECT Id, EmployeeId, DateOfReport, Task, HoursOfWork, Comments, 'Delete'
    FROM deleted
PRINT 'FOR DELETE trigger fired.'
GO

--UPDATE--
DROP TRIGGER trg_WorkHours_Update
GO
CREATE TRIGGER trg_WorkHours_Update ON WorkHours
FOR UPDATE 
AS
INSERT INTO WorkHoursLog(WorkHoursId,EmployeeId, DateOfReport, Task, HoursOfWork, Comments, [Action])
    SELECT Id, EmployeeId, DateOfReport, Task, HoursOfWork, Comments, 'UPDATE'
    FROM inserted
PRINT 'FOR UPDATE trigger fired.'
GO


--Trigers tests--

--DELETE--
DELETE FROM  WorkHours 
WHERE EmployeeId=25


--INSERT--
DECLARE @counter INT
SET @counter=31

INSERT INTO WorkHours(EmployeeId,DateOfReport,Task,HoursOfWork,Comments)
VALUES (@counter,GETDATE(),'task'+CONVERT(VARCHAR(5), @counter),8,'comment'+CONVERT(VARCHAR(5), @counter))

--UPDATE--
UPDATE WorkHours
SET HoursOfWork=9 
WHERE HoursOfWork=8



--30 Start a database transaction, delete all employees from the 'Sales' department along with 
--	 all dependent records from the pother tables. At the end rollback the transaction.

BEGIN TRAN
	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE WorkHours
	DROP CONSTRAINT FK_WorkHours_Employees

	DELETE FROM Employees
	SELECT d.Name
	FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

--31 Start a database transaction and drop the table EmployeesProjects.
--	 Now how you could restore back the lost table data?

--BEGIN TRAN

--DROP TABLE EmployeesProjects

--ROLLBACK TRAN



--32 Find how to use temporary tables in SQL Server. Using temporary tables backup all records
--	 from EmployeesProjects and restore them back after dropping and re-creating the table.

BEGIN TRAN

SELECT *  INTO  #Temp_EmployeesProjects
FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * INTO EmployeesPRojects
FROM #Temp_EmployeesProjects

ROLLBACK TRAN
