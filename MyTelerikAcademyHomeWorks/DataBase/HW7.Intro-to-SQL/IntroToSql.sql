
--01 What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
	-- SQL stands for Structured Query Language. SQL is used to communicate with a database. 
	-- It is the standard language for relational database management systems.
	-- SQL statements are used to perform tasks such as:
		-- defining / modifying the database schema using DML
		-- searching / modifying table data using DDL
	-- DML stands for Data Manipulation Language and includes the commands SELECT, INSERT, UPDATE, DELETE
	-- DDL stands for Data Definition Language and includes the commands CREATE, DROP, ALTER, GRANT, REVOKE
--02 What is Transact-SQL (T-SQL)?
	-- T-SQL(Transact SQL) is an extension to the standard SQL language. It is the standard language used in MS SQL Server.
    -- Supports constructions used in the high-level procedural programming languages: if statements, loops, exceptions 
    -- T-SQL is used for writing stored procedures, functions, triggers, etc.
--03 Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
--	 (I type here the common statements USE and GO)
USE TelerikAcademy
GO
--04 Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT *
FROM Departments
--05 Write a SQL query to find all department names.
SELECT Name AS 'Department Name'
FROM Departments
--06 Write a SQL query to find the salary of each employee.
SELECT EmployeeID, FirstName, LastName, Salary
FROM Employees
--07 Write a SQL to find the full name of each employee.
SELECT EmployeeID AS EmplId, FirstName+' '+LastName AS 'Full Name'
FROM Employees
--08 Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com.
--	 Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT EmployeeID AS EmplId, FirstName+'.'+LastName+'@telerik.com' AS 'Employee email'
FROM Employees
--09 Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary 
FROM Employees
--10 Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name, JobTitle
FROM Employees
WHERE JobTitle LIKE 'Sales Repre%'
--11 Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name
FROM Employees
WHERE FirstName LIKE 'Sa%'
--12 Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name
FROM Employees
WHERE LastName LIKE '%ei%'
--13 Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
--14 Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
--15 Write a SQL query to find all employees that do not have manager.
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name, ManagerID
FROM Employees
WHERE ManagerID IS NULL
--16 Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT EmployeeID AS EmplId,FirstName+' '+LastName AS Name, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC
--17 Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 EmployeeID AS EmplId,FirstName+' '+LastName AS Name, Salary
FROM Employees
ORDER BY Salary DESC
--18 Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.EmployeeID AS EmplId, e.FirstName+' '+e.LastName AS Name, a.AddressText AS Address
FROM Employees AS e INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.EmployeeID
--19 Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.EmployeeID AS EmplId, e.FirstName+' '+e.LastName AS Name, a.AddressText AS Address
FROM Employees AS e, Addresses AS a
WHERE e.AddressID = a.AddressID
ORDER BY e.EmployeeID
--20 Write a SQL query to find all employees along with their manager.
SELECT e.FirstName+' '+e.LastName AS 'Employee Name', m.FirstName+' '+m.LastName AS 'Manager'
FROM Employees e INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID 
ORDER BY e.EmployeeID 
--21 Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName+' '+e.LastName AS 'Employee Name', m.FirstName+' '+m.LastName AS 'Manager', a.AddressText
FROM Employees e INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
JOIN Addresses a
ON e.AddressID = a.AddressID
ORDER BY e.EmployeeID 
--22 Write a SQL query to find all departments and all town names as a single list. Use UNION.
	-- UNION (without ALL) will unite the Name columns from both tables, ordering by the DepartmentsUnionTowns column ASC
SELECT Name AS DepartmentsUnionTowns 
FROM Departments
UNION
SELECT Name AS DepartmentsUnionTowns
FROM Towns

	-- UNION ALL will "glue" the Name column from the TOWNS table after the Name column from the DEPARTMENTS table
SELECT Name AS DepartmentsUnionAllTowns 
FROM Departments
UNION ALL
SELECT Name AS DepartmentsUnionAllTowns
FROM Towns
--23 Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join.
--Rewrite the query to use left outer join.
SELECT e.FirstName+' '+e.LastName AS [Employee Name], m.FirstName+' '+m.LastName AS Manager
FROM Employees m RIGHT OUTER JOIN Employees e
ON e.ManagerID = m.EmployeeID 
ORDER BY e.EmployeeID

SELECT e.FirstName+' '+e.LastName AS [Employee Name], m.FirstName+' '+m.LastName AS Manager
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID 
ORDER BY e.EmployeeID 
--24 Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT  e.EmployeeID AS EmplId, e.FirstName+' '+e.LastName AS [Employee Name], YEAR(e.HireDate) AS [Hire Date]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN('Sales', 'Finance') AND YEAR(e.HireDate) BETWEEN 1995 AND 2005