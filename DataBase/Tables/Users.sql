﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT Identity NOT NULL,
    [NationalNumber] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [AdCity] NVARCHAR(50) NOT NULL, 
    [AdPostalCode] INT NOT NULL, 
    [AdStreet] NVARCHAR(50) NOT NULL, 
    [AdNumber] INT NOT NULL, 
    [AdBox] NVARCHAR(5) NULL, 
    [MobilePhone] NVARCHAR(50) NULL, 
    [Login] NVARCHAR(320) UNIQUE NOT NULL, 
    [Password] BINARY(64) NOT NULL, 
    [Gender] NCHAR(5) NOT NULL, 
    [Photo] NVARCHAR(MAX) NULL, 
    [PersonalNote] NVARCHAR(MAX) NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [FirstLogin] DATE NULL, 
    [Email] NVARCHAR(320) NULL, 
    [ClassId] INT NULL,

    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Users_NationalNumber] UNIQUE (NationalNumber), 
    CONSTRAINT [FK_Users_ClassId] FOREIGN KEY (ClassId) REFERENCES Classes(Id)
)
