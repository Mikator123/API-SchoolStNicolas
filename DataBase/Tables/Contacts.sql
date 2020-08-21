﻿CREATE TABLE [dbo].[Contacts]
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
    [Gender] NVARCHAR(5) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Contacts_Gender] CHECK (Gender = 'M' or Gender = 'F' or Gender = 'Both'),  

)
