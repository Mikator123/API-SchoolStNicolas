CREATE TABLE [dbo].[SchoolRules]
(
	[Id] INT Identity NOT NULL,
    [RuleName] NVARCHAR(50) UNIQUE NOT NULL, 
    [RuleDescription] NVARCHAR(MAX) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_SchoolRules] PRIMARY KEY ([Id])
)

