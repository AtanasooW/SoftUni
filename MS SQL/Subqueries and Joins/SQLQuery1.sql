--1
SELECT TOP(5) e.EmployeeID,e.JobTitle,e.AddressID,a.AddressText FROM Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID ORDER BY e.AddressID
--2
SELECT TOP(50) e.FirstName ,e.LastName,t.Name,a.AddressText FROM Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID JOIN Towns AS t ON t.TownID = a.TownID ORDER BY e.FirstName,e.LastName
--3
SELECT e.EmployeeID, e.FirstName ,e.LastName,d.Name FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID WHERE d.Name = 'Sales' ORDER BY e.EmployeeID
--4
SELECT TOP(5) e.EmployeeID, e.FirstName ,e.Salary,d.Name FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID WHERE e.Salary > 15000 ORDER BY e.DepartmentID
--5
SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID WHERE ep.EmployeeID is null ORDER BY e.EmployeeID
--6

SELECT e.FirstName ,e.LastName,e.HireDate,d.Name AS DeptName FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID WHERE e.HireDate > '1999-01-01' AND d.Name IN( 'Sales', 'Finance') ORDER BY e.HireDate
SELECT * FROM Projects
--7
SELECT TOP(5) e.EmployeeID ,e.FirstName ,p.Name AS ProjectName FROM EmployeesProjects AS ep 
JOIN Employees AS e ON ep.EmployeeID  = e.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL ORDER BY e.EmployeeID
--8
SELECT e.EmployeeID ,e.FirstName ,
CASE
WHEN YEAR(p.StartDate) >= 2005 THEN NULL
ELSE p.Name
END
AS ProjectName FROM EmployeesProjects AS ep 
JOIN Employees AS e ON ep.EmployeeID  = e.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
--9
USE SoftUni
SELECT * FROM Employees
SELECT * FROM Addresses
SELECT * FROM Departments
SELECT * FROM EmployeesProjects
SELECT * FROM Projects
SELECT * FROM Towns
SELECT e.EmployeeID ,e.FirstName,e.ManagerID ,m.FirstName 
FROM Employees AS e JOIN Employees AS m ON e.ManagerID = m.EmployeeID 
WHERE e.ManagerID IN (3,7) ORDER BY EmployeeID
--10
SELECT TOP(50) e.EmployeeID 
,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName
,CONCAT(m.FirstName, ' ', m.LastName) AS ManegerName
,d.Name AS DEpartmentName
FROM Employees AS e JOIN Employees AS m ON e.ManagerID = m.EmployeeID 
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID ORDER BY EmployeeID
--11

SELECT TOP(1) AVG(Salary) AS MinAverageSalary FROM Employees 
GROUP BY DepartmentID
ORDER BY MinAverageSalary
--12
USE Geography

SELECT mc.CountryCode
,m.MountainRange
,p.PeakName
,p.Elevation
FROM MountainsCountries as mc 
JOIN Mountains AS m ON mc.MountainId = m.Id 
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation >= 2835
ORDER BY p.Elevation DESC
--13
SELECT mc.CountryCode, COUNT(m.MountainRange)
FROM MountainsCountries as mc 
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE mc.CountryCode IN ('BG', 'US', 'RU')
GROUP BY mc.CountryCode
--14

SELECT TOP(5) c.CountryName
,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode 
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF' 
ORDER BY CountryName
--16
SELECT COUNT(CountryName)
FROM Countries AS c
LEFT JOIN MountainsCountries AS mr ON c.CountryCode = mr.CountryCode 
WHERE MountainId IS NULL

SELECT * FROM Rivers
SELECT * FROM Mountains
SELECT * FROM Countries
SELECT * FROM MountainsCountries

SELECT *
FROM Countries AS c
LEFT JOIN MountainsCountries AS mr ON c.CountryCode = mr.CountryCode 
--17
SELECT TOP(5) c.CountryName
,MAX(p.Elevation)
,MAX(r.Length)
FROM MountainsCountries as mc 
JOIN Countries AS c ON c.ContinentCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id 
JOIN Peaks AS p ON m.Id = p.MountainId
JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode 
JOIN Rivers AS r ON cr.RiverId = r.Id
ORDER BY p.Elevation DESC, r.Length, c.CountryName;