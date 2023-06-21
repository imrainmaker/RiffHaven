CREATE TABLE [dbo].[Status] (
    [Id_Status] INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Status] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

