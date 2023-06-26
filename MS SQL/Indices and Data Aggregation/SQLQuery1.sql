--1
SELECT * FROM WizzardDeposits
--2
SELECT MAX(MagicWandSize) FROM WizzardDeposits
--3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup
--4
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
--5
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
GROUP BY DepositGroup
--6
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
--7
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) <= 150000
ORDER BY SUM(DepositAmount) DESC
--8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup
--9
SELECT *,COUNT(*) FROM(
SELECT CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN AGE >= 61 THEN '[61+]'
END AS AgeGroup FROM WizzardDeposits) AS AgeGroupTable
GROUP BY AgeGroup
--10
SELECT * FROM WizzardDeposits

SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName, 1, 1)
--11
SELECT DepositGroup, IsDepositExpired,AVG(DepositInterest) AS AverageInterest FROM WizzardDeposits 
WHERE DepositStartDate >= '01.01.1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired
--13
SELECT DepartmentID,SUM(Salary) FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID
--14
SELECT DepartmentID, MIN(Salary) FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate >= '01/01/2000'
GROUP BY DepartmentID
--15
SELECT * INTO Emp2 FROM Employees
WHERE Salary > 30000

DELETE FROM Emp2
WHERE ManagerID = 42

UPDATE Emp2 
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentId, AVG(Salary) FROM Emp2
GROUP BY DepartmentID
--16
SELECT DepartmentID,MAX(Salary) FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
--17
SELECT COUNT(*) FROM Employees
WHERE ManagerID IS NULL