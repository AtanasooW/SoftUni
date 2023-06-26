CREATE DATABASE [Minions];

USE [Minions];

CREATE TABLE Minions(
Id int IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NULL,
Age int NULL
CONSTRAINT PK_Minions PRIMARY KEY(Id) 
);
CREATE TABLE Towns(
Id int IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(100) NULL,
CONSTRAINT PK_Towns PRIMARY KEY(Id) 
);
ALTER TABLE Minions 
ADD [TownId] int FOREIGN KEY REFERENCES Towns(Id);
--For Judge  --04
INSERT INTO Towns (Id, Name) VALUES (1, 'Sofia'),(2, 'Plovdiv'),(3, 'Varna')

INSERT INTO Minions (Id,Name, Age, TownID) VALUES (1, 'Kevin', 22, 1),(2, 'Bob', 15, 3),(3, 'Steward', NULL, 2)
--To here
TRUNCATE TABLE Minions

DROP Table Minions;
DROP  TABLE [dbo].Towns;
-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(26) NOT NULL,
ProfilePricture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT
)
INSERT INTO Users(Username,Password,ProfilePricture,LastLoginTime,IsDeleted) VALUES
('Petar','Penq',NULl,'10-20-2020',1),
('Vanesa','Nase',NULl ,'12-25-2022',0),
('Cow','e',NULl ,'01-29-2021',1),
('Deyvid','mnogo',NULl ,'12-07-2020',NULL),
('Gey','gotin',NULl ,'12-12-2021',0)
--9
ALTER TABLE Users DROP CONSTRAINT [PK__Users__3214EC0713DBEA66];
ALTER TABLE Users ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id,Username);
--10
ALTER TABLE Users ADD CONSTRAINT CHK_PasswordMinLen CHECK(LEN(Password) >= 5)

--11
ALTER TABLE Users ADD CONSTRAINT DF_LastLogingTime DEFAULT GETDATE() FOR LastLoginTime


--12
ALTER TABLE Users DROP CONSTRAINT PK_IdUsername;
Alter TABLE Users ADD CONSTRAINT PK_Id PRIMARY KEY (Id);

ALTER TABLE Users ADD CONSTRAINT UC_Username UNIQUE(Username);
ALTER TABLE Users ADD CONSTRAINT CHK_Username CHECK(LEN(Username) >= 3);
--13
Use [master]
CREATE DATABASE Movie

USE [Movie]

CREATE TABLE Directors(
Id int IDENTITY PRIMARY KEY NOT NULL,
DerectorName NVARCHAR(50) NOT NULL,
Notes VARCHAR(MAX) 
)
CREATE TABLE Genres(
Id int IDENTITY PRIMARY KEY NOT NULL,
GenreName NVARCHAR(50) NOT NULL,
Notes VARCHAR(MAX) 
)
CREATE TABLE Categories (
Id int IDENTITY PRIMARY KEY NOT NULL,
CategoryName NVARCHAR(50) NOT NULL,
Notes VARCHAR(MAX) 
)
CREATE TABLE Movies(
Id int IDENTITY PRIMARY KEY NOT NULL,
Title NVARCHAR(50) NOT NULL,
DirectorId int NOT NULL, 
CopyrightYear DATE,
Length int,
GenreId int NOT NULL,
CategoryId int NOT NULL,
Rating DECIMAL,
Notes VARCHAR(MAX)
)
INSERT INTO Directors(DerectorName,Notes) VALUES
('Petar','Imam zmiq v gashtite'),
('Vanesa',NULL),
('Cow',NULL),
('Deyvid',NULL),
('Gey',NULL)


INSERT INTO Genres(GenreName,Notes) VALUES
('Horror','Imam zmiq v gashtite i ubieca idva :D'),
('Action',NULL),
('Comedy',NULL),
('Animated',NULL),
('Cars:)',NULL)

INSERT INTO Categories(CategoryName,Notes) VALUES
('Horror','Imam zmiq v gashtite i ubieca ne idva :D'),
('cars',NULL),
('porno',NULL),
('anime',NULL),
('animated porno:)',NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('Horror',1,'10-10-2020', 150,2,3,4,NULL),
('Srabsko',3,'10-15-2020', 180,5,5,2,NULL),
('Need For Speed',4,'10-18-2020', 120,3,4,3,'Imam R34'),
('Psyco2',5,'10-20-2020', 180,2,5,4,NULL),
('Cars4',2,'10-13-2020', 115,3,4,5,NULL)
--SELECT * FROM Movies