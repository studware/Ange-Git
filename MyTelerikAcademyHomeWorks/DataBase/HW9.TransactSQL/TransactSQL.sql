-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN)
--								     and Accounts(Id(PK), PersonId(FK), Balance).

USE master
GO

USE BankAccounts
GO

if not exists (SELECT * FROM sysobjects WHERE name='Persons' and xtype='U')
    CREATE TABLE Persons (Id int IDENTITY NOT NULL PRIMARY KEY,
							FirstName nvarchar(15) NOT NULL, LastName nvarchar(15) NOT NULL,
							SSN nvarchar(20) NOT NULL)
GO

if not exists (SELECT * FROM sysobjects WHERE name='Accounts' and xtype='U')
    CREATE TABLE Accounts (Id int IDENTITY NOT NULL PRIMARY KEY,
							PersonId int NOT NULL FOREIGN KEY REFERENCES Persons(Id)
							ON DELETE CASCADE
							ON UPDATE CASCADE,
							Balance money NOT NULL
						)
GO

--       o Insert few records for testing.

DECLARE @counter tinyint
SET @counter = 5
WHILE @counter > 0
	BEGIN
		INSERT INTO Persons(FirstName, LastName, SSN)
		VALUES ('Ivan ' + CAST(@counter AS varchar(1)),
				'Draganov ' + CAST(@counter AS varchar(1)),
				'SSNabcdef' + CAST(@counter AS varchar(1)))
		SET @counter = @counter - 1
	END
GO
	
-- Insert few accounts for testing purposes
DECLARE @counter tinyint
SET @counter = 5
WHILE @counter > 0
	BEGIN
		INSERT INTO Accounts(PersonId, Balance)
		VALUES (@counter, 100000+@counter)
		SET @counter = @counter - 1
	END
GO

--       o Write a stored procedure that selects the full names of all persons.
CREATE PROC usp_SelectAllFullNames
AS
  SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM Persons
GO

EXEC usp_SelectAllFullNames

DROP PROC usp_SelectAllFullNames

GO

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_SelectEmployeesHavingEnoughMoney(
  @MoneyDownLimit money = 1000)
AS
  SELECT FirstName + ' ' + LastName AS [Full Name], Balance 
  FROM Persons JOIN Accounts
  ON Persons.Id = Accounts.PersonId
  WHERE Accounts.Balance > @MoneyDownLimit
  ORDER BY Accounts.Balance
GO

EXEC usp_SelectEmployeesHavingEnoughMoney 60000
GO

EXEC usp_SelectEmployeesHavingEnoughMoney
GO

DROP PROC usp_SelectEmployeesHavingEnoughMoney
GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--    o  It should calculate and return the new sum.
CREATE FUNCTION ufn_CalcSumWithCompoundInterest (@sum money, @yearlyInterest float, @montsNumber tinyint)
  RETURNS money
AS
BEGIN
	DECLARE @accumulatedSum money = @sum
	DECLARE @lnArgument money = @yearlyInterest/(CONVERT(money,100*12))
	DECLARE @counter tinyint
	SET @counter = @montsNumber
	WHILE @counter > 0
		BEGIN
			SET @accumulatedSum += @accumulatedSum*@lnArgument
			SET @counter = @counter - 1
		END

	RETURN ROUND(@accumulatedSum,2)
END
GO
--    o  Write a SELECT to test whether the function works as expected.
SELECT Balance, 4.8 AS [Yearly Interest Rate], 4 AS [Number of Months], 
		dbo.ufn_CalcSumWithCompoundInterest(Balance, 4.8, 4) AS [Accumulated Sum]
FROM Accounts

GO

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--    It should take the AccountId and the interest rate as parameters.
CREATE PROCEDURE usp_CalculateCompoundInterestMonthly(@accountId int, @yearlyInterest float)
AS
	DECLARE @balance money
	SELECT @balance = Balance FROM Accounts WHERE Id = @accountId
	
	DECLARE @newBalance money
	SELECT @newBalance = dbo.ufn_CalcSumWithCompoundInterest(@balance, @yearlyInterest, 1)
	
	SELECT p.FirstName, p.LastName, a.Balance, @newBalance AS [New Balance]
	FROM Persons p
	JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Id = @accountId
GO

DECLARE @yearlyInterest float =  4.8
EXEC usp_CalculateCompoundInterestMonthly 5, @yearlyInterest

DROP PROC usp_CalculateCompoundInterestMonthly
DROP FUNCTION dbo.ufn_CalcSumWithCompoundInterest
GO

-- 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROCEDURE dbo.usp_WithdrawMoney(@accountId int, @money money)
AS
    BEGIN TRAN
		SELECT Balance AS [Old Balance]
		FROM Accounts
		WHERE Id=@accountId

        UPDATE Accounts
        SET Balance -= @money
        WHERE Id = @accountId

		SELECT Balance AS [Withdrawal: New Balance]
		FROM Accounts
		WHERE Id=@accountId
    COMMIT TRAN
GO

CREATE PROCEDURE dbo.usp_DepositMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance += @money
        WHERE Id = @accountId

		SELECT Balance AS [Deposit: New Balance]
		FROM Accounts
		WHERE Id=@accountId
    COMMIT TRAN
GO

EXEC usp_WithdrawMoney 2, 100
GO
EXEC usp_DepositMoney 2, 400
GO

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--     Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
--IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Logs' and xtype='U')
    CREATE TABLE Logs (LogId int IDENTITY NOT NULL PRIMARY KEY,
						AccountId int NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
						OldSum money NOT NULL,
						NewSum money Not Null
					)
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
	IF (EXISTS(SELECT * FROM inserted WHERE Balance IS NULL) OR
		EXISTS(SELECT * FROM inserted WHERE Balance <= 0))
		BEGIN
		  RAISERROR('Balance cannot be NULL, zero or negative.', 16, 1)
		  ROLLBACK TRAN
		END
	ELSE 
		BEGIN
			DECLARE @oldSum money;
			SELECT @oldSum = Balance FROM deleted;

			INSERT INTO Logs(AccountId, OldSum, NewSum)
				SELECT Id, @oldSum, Balance 
				FROM inserted;
		END
GO

BEGIN TRAN
EXEC usp_WithdrawMoney 2, 12000
COMMIT TRAN

BEGIN TRAN
EXEC usp_DepositMoney 2, 2000
COMMIT TRAN
GO

DROP PROC usp_WithdrawMoney
DROP PROC usp_DepositMoney
GO

--UPDATE Accounts SET Balance= 123456.78 WHERE Id=1

--UPDATE Accounts SET Balance= -1234.56 WHERE Id=1

--UPDATE Accounts SET Balance=0
  
--UPDATE Accounts SET Balance=NULL

DROP TRIGGER tr_AccountsUpdate
DROP TABLE Logs 
GO

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
--    and all town's names that are comprised in given set of letters.
--     Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
use TelerikAcademy
GO

CREATE FUNCTION ufn_CheckName(@nameToCheck NVARCHAR(50), @letters nvarchar(50))
RETURNS int AS
BEGIN
    DECLARE @i int = 1
	DECLARE @currentChar nvarchar(1)
    WHILE (@i <= LEN(@nameToCheck))
		BEGIN
			SET @currentChar = SUBSTRING(@nameToCheck,@i, 1)
				IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
					BEGIN  
						RETURN 0
					END
			SET @i = @i + 1
		END
    RETURN 1
END
GO

CREATE FUNCTION dbo.ufn_AllEmploeeysAndTownByStringCondition(@format nvarchar(50))
RETURNS @table TABLE
	([Name] nvarchar(50) NOT NULL)
AS
BEGIN
	INSERT @table
	SELECT newTbl.LastName FROM
		(SELECT LastName FROM Employees
		UNION
		SELECT Name FROM Towns) as newTbl
		WHERE dbo.ufn_CheckName(newTbl.LastName, @format) > 0
	 RETURN
END
GO

SELECT * FROM ufn_AllEmploeeysAndTownByStringCondition('oiseltmiahf')

DROP FUNCTION dbo.ufn_CheckName
DROP FUNCTION dbo.ufn_AllEmploeeysAndTownByStringCondition
GO

-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
--	  *Write a T-SQL script that shows for each town a list of all employees that live in it.
--     Sample output:
--			Sofia -> Martin Kulov, George Denchev
--			Ottawa -> Jose Saraiva
--			…
DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
  JOIN Addresses a
  ON e.AddressID = a.AddressID
  JOIN Towns t
  ON a.TownID = t.TownID

OPEN empCursor
DECLARE @firstName nvarchar(50), @lastName nvarchar(50), @town nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

WHILE @@FETCH_STATUS = 0
  BEGIN
  			  DECLARE empCursor1 CURSOR READ_ONLY FOR
			  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
			  JOIN Addresses a
			  ON e.AddressID = a.AddressID
			  JOIN Towns t
			  ON a.TownID = t.TownID

			OPEN empCursor1
			DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @town1 nvarchar(50)
			FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1

			WHILE @@FETCH_STATUS = 0
			  BEGIN
			  IF(@town=@town1 AND @firstName != @firstName1 AND @lastName != @lastName1)
				  BEGIN
					PRINT @town+':'+ @firstName + ' ' + @lastName + ':' + @firstName1 + ' ' + @lastName1 
				  END
				FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1
			  END

			CLOSE empCursor1
			DEALLOCATE empCursor1

    FETCH NEXT FROM empCursor  INTO @firstName, @lastName, @town
  END

CLOSE empCursor
DEALLOCATE empCursor


--9.	*Write a T-SQL script that shows for each town a list of all employees that live in it.
--	*	_Sample output_:	
--```sql
--Sofia -> Martin Kulov, George Denchev
--Ottawa -> Jose Saraiva
--…
--```

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT DISTINCT t.Name, t.Name AS [fullNames] FROM Towns t

OPEN empCursor
DECLARE @theTown nvarchar(50), @fullNames nvarchar(2000)
FETCH NEXT FROM empCursor INTO @theTown, @fullNames

WHILE @@FETCH_STATUS = 0
  BEGIN
  			  DECLARE empCursor1 CURSOR READ_ONLY FOR
			  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
			  JOIN Addresses a
			  ON e.AddressID = a.AddressID
			  JOIN Towns t
			  ON a.TownID = t.TownID

			OPEN empCursor1
			DECLARE @firstName2 nvarchar(50), @lastName2 nvarchar(50), @town2 nvarchar(50)
			FETCH NEXT FROM empCursor1 INTO @firstName2, @lastName2, @town2

			WHILE @@FETCH_STATUS = 0
			  BEGIN
			  IF(@town=@town1)
				  BEGIN
					SET @fullNames+= @firstName1 + ' ' + @lastName1 + ', ' 
				  END
				FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1
			  END
			  
			CLOSE empCursor1
			DEALLOCATE empCursor1
		PRINT @town + ' -> '+ @fullNames
    FETCH NEXT FROM empCursor INTO @town, @fullNames
  END

CLOSE empCursor
DEALLOCATE empCursor

--10.	Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by '`,`'.
--	*	For example the following SQL statement should return a single string:

--```sql
--SELECT StrConcat(FirstName + ' ' + LastName)
--FROM Employees
--```

USE TelerikAcademy
GO
IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 
IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      
CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'D:\Ange-Git\MyTelerikAcademyHomeWorks\DataBase\HW9.TransactSQL\SqlStringConcatenation.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 
CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 
SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO
DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO
