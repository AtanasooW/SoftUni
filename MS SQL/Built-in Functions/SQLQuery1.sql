--1
USE SoftUni;
SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'Sa%' ;
--2
SELECT FirstName, LastName FROM Employees WHERE LastName LIKE '%ei%' ;
--3
SELECT FirstName FROM Employees WHERE DepartmentID = 3 OR DepartmentID = 10 AND YEAR(HireDate) BETWEEN 1995 AND 2005;
--4
SELECT FirstName, LastName FROM Employees WHERE JobTitle Not LIKE '%Engineer%';
--5
SELECT * FROM Employees;
SELECT [Name] FROM Towns WHERE LEN([Name]) BETWEEN 5 AND 6 ORDER BY Name
--6
SELECT TownID, Name FROM Towns WHERE Name LIKE 'M%' OR Name LIKE 'K%' OR Name LIKE 'B%' OR Name LIKE 'E%' ORDER BY Name;
--7
SELECT TownID, Name FROM Towns WHERE Name NOT LIKE 'B%' AND Name NOT LIKE 'R%' AND Name NOT LIKE 'D%' ORDER BY Name;
--8

CREATE VIEW [V_EmployeesHiredAfter2000] AS SELECT FirstName, LastName FROM Employees WHERE YEAR(HireDate) > 2000
SELECT FirstName, LastName FROM V_EmployeesHiredAfter2000;
DROP VIEW V_EmployeesHiredAfter2000;
--9
SELECT FirstName, LastName FROM Employees WHERE LEN(LastName) = 5;
--10
SELECT * FROM (SELECT EmployeeID,FirstName, LastName,Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS DENSE_RANK FROM Employees WHERE Salary BETWEEN 10000 AND 50000) AS MyTable ORDER BY Salary DESC;
--11
SELECT * FROM (SELECT 
EmployeeID,
FirstName, 
LastName,
Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank 
FROM Employees WHERE Salary BETWEEN 10000 AND 50000) AS MyTable WHERE Rank = 2  ORDER BY Salary DESC;
--12
SELECT CountryName,IsoCode FROM Countries WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a','')) >= 3 ORDER BY IsoCode;
SELECT * FROM Peaks;
SELECT * FROM Rivers;
--13
SELECT PeakName, RiverName,LOWER(CONCAT((PeakName), '', SUBSTRING(LOWER(RiverName), 2,LEN(RiverName)))) AS Mix FROM Peaks,Rivers WHERE RIGHT(PeakName,1) = LEFT(RiverName,1) ORDER BY Mix ;
--14
USE Diablo;
SELECT TOP(50) Name, FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games WHERE Year(Start) BETWEEN 2011 AND 2012 ORDER BY Start; 
--15 
SELECT Username, SUBSTRING(Email,CHARINDEX('@', Email) + 1, Len(Email)) AS EmailProvider From Users ORDER BY EmailProvider,Username
--16
SELECT * FROM Users;
SELECT Username,IpAddress From Users WHERE IpAddress LIKE '___.1_%._%.___' ORDER BY Username
--17
