CREATE TABLE [dbo].[Frets] (
    [Id_Frets] INT IDENTITY (1, 1) NOT NULL,
    [Frets]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Frets] ASC),
    UNIQUE NONCLUSTERED ([Frets] ASC)
);

