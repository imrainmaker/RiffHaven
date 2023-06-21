CREATE TABLE [dbo].[Scales] (
    [Id_Scales] INT IDENTITY (1, 1) NOT NULL,
    [Scale]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Scales] ASC),
    UNIQUE NONCLUSTERED ([Scale] ASC)
);

