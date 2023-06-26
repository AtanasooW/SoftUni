--1
CREATE DATABASE Boardgames;
GO
USE Boardgames;
GO

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(

Id INT PRIMARY KEY IDENTITY,
StreetName NVARCHAR(100) NOT NULL,
StreetNumber INT NOT NULL,
Town VARCHAR(30) NOT NULL,
Country VARCHAR(50) NOT NULL,
ZIP INT NOT NULL
)
CREATE TABLE Publishers(

Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30) UNIQUE NOT NULL,
AddressId INT FOREIGN KEY(AddressId) REFERENCES Addresses(Id) NOT NULL,
Website VARCHAR(40),
Phone VARCHAR(20) 
)
CREATE TABLE PlayersRanges(

Id INT PRIMARY KEY IDENTITY,
PlayersMin INT NOT NULL,
PlayersMax INT NOT NULL
)
CREATE TABLE Boardgames(

Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30) NOT NULL,
YearPublished INT NOT NULL,
Rating DECIMAL(10,2) NOT NULL,
CategoryId INT FOREIGN KEY(CategoryId) REFERENCES Categories(Id) NOT NULL,
PublisherId INT FOREIGN KEY(PublisherId) REFERENCES Publishers(Id) NOT NULL,
PlayersRangeId INT FOREIGN KEY(PlayersRangeId) REFERENCES PlayersRanges(Id) NOT NULL
)
CREATE TABLE Creators(

Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(30) NOT NULL
)
CREATE TABLE CreatorsBoardgames(

CreatorId INT FOREIGN KEY(CreatorId) REFERENCES Creators(Id) NOT NULL,
BoardgameId INT FOREIGN KEY(BoardgameId) REFERENCES Boardgames(Id) NOT NULL,
PRIMARY KEY(CreatorId,BoardgameId)
)
--2
INSERT INTO Boardgames (Name,YearPublished,Rating,CategoryId,PublisherId,PlayersRangeId) VALUES
('Deep Blue',2019,5.67,1,15,7),
('Paris',2016,9.78,7,1,5),
('Catan: Starfarers',2021,9.87,7,13,6),
('Bleeding Kansas',2020,3.25,3,7,4),
('One Small Step',2019,5.75,5,9,2)

INSERT INTO Publishers (Name,AddressId,Website,Phone) VALUES
('Agman Games',5,'www.agmangames.com','+16546135542'),
('Amethyst Games',7,'www.amethystgames.com','+15558889992'),
('BattleBooks',13,'www.battlebooks.com','+12345678907')
--3
UPDATE PlayersRanges SET PlayersMax += 1 WHERE PlayersMin = 2 AND PlayersMax = 2
UPDATE Boardgames SET Name += 'V2' WHERE YearPublished >= 2020
--4
DELETE CreatorsBoardgames WHERE BoardgameId IN (1,16,31)
DELETE Boardgames WHERE PublisherId = 1;
DELETE Publishers WHERE AddressId = 5;
DELETE Addresses WHERE Town LIKE 'L%';
--5
SELECT Name,Rating FROM Boardgames ORDER BY YearPublished, Name DESC
--6
SELECT b.Id,b.Name,b.YearPublished,c.Name  FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games','Wargames')
ORDER BY YearPublished DESC
--7
SELECT * FROM CreatorsBoardgames	
SELECT id,CONCAT(FirstName, ' ', LastName) AS CreatorName,Email FROM Creators WHERE Id IN (5,7)
--8
SELECT * FROM PlayersRanges
SELECT TOP(5) b.Name,b.Rating,c.Name FROM Boardgames AS b
JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE b.Rating > 7 AND LOWER(b.Name) LIKE '%a%' OR b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY b.Name, b.Rating DESC
--9
SELECT CONCAT(FirstName, ' ', LastName) AS CreatorName, c.Email ,MAX(b.Rating) FROM Creators AS c 
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName,LastName,c.Email
--10
SELECT c.LastName, CEILING(AVG(b.Rating)) AS AverageRating,p.Name FROM CreatorsBoardgames AS cb
JOIN Creators AS c ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p On b.PublisherId = p.Id
WHERE p.Name = 'Stonemaier Games'
GROUP BY c.LastName,b.Rating,p.Name,c.Id
ORDER BY AVG(b.Rating) DESC
--11
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))  
RETURNS INT
AS
BEGIN
		RETURN(SELECT COUNT(c.Id) FROM Creators AS c
		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId 
		WHERE c.FirstName = @name)
END

SELECT COUNT(c.Id) FROM Creators AS c
		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId 
		WHERE c.FirstName = 'Bruno'
--12
CREATE PROC usp_SearchByCategory(@category VARCHAR (50))
AS
BEGIN
			SELECT b.Name,b.YearPublished,b.Rating,c.Name,p.Name,CONCAT(pr.PlayersMin, ' people') AS MinPlayers,CONCAT(pr.PlayersMax, ' people') AS MaxPlayers  FROM Boardgames AS b
			JOIN Categories AS c ON b.CategoryId = c.Id
			JOIN Publishers AS p ON b.PublisherId = p.Id
			JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
			WHERE c.Name = @category
			ORDER BY p.Name, b.YearPublished DESC

END