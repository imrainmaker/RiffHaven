CREATE TABLE [dbo].[Colors] (
    [Id_Colors] INT          IDENTITY (1, 1) NOT NULL,
    [Color]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Colors] ASC),
    UNIQUE NONCLUSTERED ([Color] ASC)
);

