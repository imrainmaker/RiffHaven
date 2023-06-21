CREATE TABLE [dbo].[Brands] (
    [Id_Brands] INT          IDENTITY (1, 1) NOT NULL,
    [Brand]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Brands] ASC),
    UNIQUE NONCLUSTERED ([Brand] ASC)
);

