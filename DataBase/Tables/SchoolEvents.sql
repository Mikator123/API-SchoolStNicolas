CREATE TABLE [dbo].[SchoolEvents]
(
	[Id] INT Identity NOT NULL, 
    [EventName] NVARCHAR(50) UNIQUE NOT NULL, 
    [EventDescription] NVARCHAR(MAX) NULL, 
    [EventDate] DATE NULL,
    [NbrOfPersons] int NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_SchoolEvents] PRIMARY KEY ([Id]),
    CONSTRAINT [UK_SchoolEvents_EventName] UNIQUE ([EventName])
)
