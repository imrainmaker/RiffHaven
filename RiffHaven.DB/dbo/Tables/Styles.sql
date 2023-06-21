CREATE TABLE [dbo].[Styles] (
    [Id_Styles] INT          IDENTITY (1, 1) NOT NULL,
    [Style]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Styles] ASC),
    UNIQUE NONCLUSTERED ([Style] ASC)
);

