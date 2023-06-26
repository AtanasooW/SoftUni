--USE master
CREATE DATABASE CigarShop
GO
USE CigarShop
GO
CREATE TABLE Sizes(
Id int IDENTITY PRIMARY KEY,
Length INT NOT NULL,
RingRange DECIMAL(10,2) NOT NULL,
CONSTRAINT Length_Ck CHECK (Length BETWEEN 10 AND 25),
CONSTRAINT RingRange_Ck CHECK (RingRange BETWEEN 1.5 AND 7.5)
)
CREATE TABLE Tastes(
Id int IDENTITY PRIMARY KEY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)
CREATE TABLE Brands(
Id int IDENTITY PRIMARY KEY,
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(MAX)
)
CREATE TABLE Cigars(
Id int PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY(BrandId) REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY(TastId) REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY(SizeId) REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar DECIMAL NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
--PRIMARY KEY(Id,SizeId)
)
CREATE TABLE Addresses(
Id int IDENTITY PRIMARY KEY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)
CREATE TABLE Clients(
Id int IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT FOREIGN KEY(AddressId) REFERENCES Addresses(Id) NOT NULL,
)
CREATE TABLE ClientsCigars(
ClientId INT FOREIGN KEY(ClientId) REFERENCES Clients(Id) NOT NULL,
CigarId INT FOREIGN KEY(CigarId) REFERENCES Cigars(Id) NOT NULL,
PRIMARY KEY(ClientId,CigarId)
)


--2
INSERT INTO Cigars(CigarName,BrandId,TastId,SizeId,PriceForSingleCigar,ImageURL) VALUES
('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town,Country,Streat,ZIP) VALUES
('Sofia','Bulgaria','18 Bul. Vasil levski',1000),
('Athens','Greece','4342 McDonald Avenue',10435),
('Zagreb','Croatia','4333 Lauren Drive',10000)

--3
SELECT * FROM Brands
UPDATE Cigars SET PriceForSingleCigar *= 1.2 WHERE TastId = 1
UPDATE Brands SET BrandDescription = 'New description' WHERE BrandDescription IS NULL
--4
SELECT * FROM Addresses
SELECT * FROM ClientsCigars
DELETE ClientsCigars WHERE ClientId IN (7,8,10)
DELETE Clients WHERE AddressId IN (7,8,10)
DELETE Addresses WHERE Country LIKE 'C%'
--7 8 10

--5
SELECT CigarName,PriceForSingleCigar,ImageURL FROM Cigars 
ORDER BY PriceForSingleCigar,CigarName DESC
--6
SELECT c.Id,c.CigarName,c.PriceForSingleCigar,t.TasteType,t.TasteStrength FROM Cigars AS c 
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY PriceForSingleCigar DESC
--7
SELECT * FROM Clients AS c 
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE c.Id != cc.ClientId

SELECT cc.ClientId, CONCAT(c.FirstName,' ', c.LastName) FROM ClientsCigars AS cc
JOIN Clients AS c ON cc.ClientId = c.Id
--GROUP BY cc.ClientId


SELECT * FROM ClientsCigars