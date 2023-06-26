CREATE DATABASE Minions;

USE Minions;

CREATE TABLE Minions(
Id int IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NULL,
Age int NULL
CONSTRAINT PKMinions PRIMARY KEY (Id)
);

INSERT INTO Minions ([Name],[Age]) VALUES ('Kravata','27')