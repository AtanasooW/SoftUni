--USE master
CREATE DATABASE Zoo;
GO
USE Zoo;
GO
CREATE TABLE Owners(
Id int IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50)
)
CREATE TABLE AnimalTypes(
Id int IDENTITY PRIMARY KEY,
AnimalType VARCHAR(30) NOT NULL,
)
CREATE TABLE Cages(
Id int IDENTITY PRIMARY KEY,
AnimalTypeId INT FOREIGN KEY(AnimalTypeID) REFERENCES AnimalTypes(Id) NOT NULL
);
CREATE TABLE Animals(
Id int IDENTITY PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY(OwnerId) REFERENCES Owners(Id),
AnimalTypeId INT FOREIGN KEY(AnimalTypeID) REFERENCES AnimalTypes(Id) NOT NULL
)
CREATE TABLE AnimalsCages(
CageId int FOREIGN KEY(CageId) REFERENCES Cages(Id) NOT NULL,
AnimalId INT FOREIGN KEY(AnimalId) REFERENCES Animals(Id) NOT NULL,
PRIMARY KEY(CageId,AnimalId)
);
CREATE TABLE VolunteersDepartments(
Id int IDENTITY PRIMARY KEY NOT NULL,
DepartmentName VARCHAR(30) NOT NULL
);
CREATE TABLE Volunteers(
Id int IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50),
AnimalId INT FOREIGN KEY(AnimalId) REFERENCES Animals(Id),
DepartmentId INT FOREIGN KEY(DepartmentId) REFERENCES VolunteersDepartments(Id) NOT NULL
)
--2
INSERT INTO Volunteers (Name, PhoneNumber,Address,AnimalId,DepartmentId) VALUES
('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1),
('Dimitur Stoev','0877564223',NULL,42,4),
('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8),
('Boryana Mileva','0888112233',NULL,31,5)
INSERT INTO Animals (Name,BirthDate,OwnerId,AnimalTypeId) VALUES
('Giraffe','2018-09-21',21,1),
('Harpy Eagle','2015-04-17',15,3),
('Hamadryas Baboon','2017-11-02',NULL,1),
('Tuatara','2021-06-30',2,4)
--3
SELECT * FROM Owners WHERE Name = 'Kaloqn Stoqnov '
SELECT * FROM Animals
UPDATE Animals SET OwnerId = 4 WHERE OwnerId IS NULL
--4
SELECT * FROM Volunteers
DELETE FROM Volunteers WHERE DepartmentId = 2
DELETE FROM VolunteersDepartments WHERE Id = 2
--5
SELECT Name,PhoneNumber,Address,AnimalId,DepartmentId FROM Volunteers 
ORDER BY Name,AnimalId,DepartmentId.
--6
SELECT Name,at.AnimalType,FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate FROM Animals as a 
JOIN AnimalTypes as at ON a.AnimalTypeId = at.Id
ORDER BY Name
--7
SELECT * FROM Animals
SELECT TOP(5) o.Name AS Owner, COUNT(*) FROM Owners AS o
JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY o.Name
ORDER BY COUNT(*) DESC,o.Name
--8
SELECT * FROM AnimalsCages
SELECT CONCAT(o.Name,'-',a.Name) AS OwnersAnimals,o.PhoneNumber,ac.CageId FROM Animals AS a 
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
JOIN Owners AS o ON a.OwnerId = o.Id
JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
WHERE at.AnimalType = 'Mammals'
ORDER BY o.Name,a.Name DESC
--9
SELECT * FROM Volunteers WHERE Name = 'Kiril Kostadinov'
SELECT TRIM('15 Lyulyak str.') FROM Volunteers

SELECT v.Name,v.PhoneNumber, SUBSTRING(v.Address, CHARINDEX(', ', v.Address) + 2, LEN(v.Address)) FROM Volunteers AS v 
JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
WHERE v.Address LIKE '%Sofia%' AND vd.DepartmentName = 'Education program assistant'
ORDER BY v.Name
--10
SELECT * FROM AnimalTypes

SELECT a.Name, YEAR(BirthDate),at.AnimalType FROM Animals AS a 
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
WHERE at.AnimalType != 'Birds' AND DATEDIFF(year, a.BirthDate, '01/01/2022') < 5 AND OwnerId IS NULL
ORDER BY a.Name
--11
SELECT * FROM VolunteersDepartments
SELECT * FROM Volunteers

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR (30)) 
RETURNS INT
AS
BEGIN
		RETURN(SELECT COUNT(v.Id) FROM Volunteers as v
		JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
		WHERE vd.DepartmentName = @VolunteersDepartment)
END

--12
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR (50))
AS
BEGIN
	IF (SELECT OwnerId FROM Animals WHERE Name = @AnimalName) IS NULL
		BEGIN
			SELECT Name,'For adoption' AS OwnersName FROM Animals WHERE Name = @AnimalName
		END
	ELSE
		BEGIN
			SELECT a.Name,o.Name AS Ownersname FROM Animals AS a 
			JOIN Owners AS o ON a.OwnerId = o.Id
			WHERE a.Name = @AnimalName
		END
END
EXEC dbo.usp_AnimalsWithOwnersOrNot 'Georgi Georgiev';
