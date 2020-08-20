﻿CREATE TABLE [dbo].[Students]
(
	[Id] INT IDENTITY NOT NULL, 
    [NationalNumber] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [AdCity] NVARCHAR(50) NOT NULL, 
    [AdPostalCode] INT NOT NULL, 
    [AdStreet] NVARCHAR(50) NOT NULL, 
    [AdNumber] INT NOT NULL, 
    [AdBox] INT NULL, 
    [MobilePhone] NVARCHAR(50) NULL, 
    [Login] NVARCHAR(320) NOT NULL, 
    [Password] BINARY(64) NOT NULL, 
    [Gender] NCHAR(5) NOT NULL, 
    [Photo] NVARCHAR(300) NULL, 
    [PersonalNote] NVARCHAR(MAX) NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [FirstLogin] DATE NULL, 
    [Email] NVARCHAR(320) NULL, 
    [ClassId] INT NOT NULL, 
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Students_ToClasses] FOREIGN KEY (ClassId) REFERENCES Classes([Id]) 
)


   