CREATE TABLE [dbo].[Tremolo] (
    [Id_Tremolo] INT          IDENTITY (1, 1) NOT NULL,
    [Tremolo]    VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Tremolo] ASC),
    UNIQUE NONCLUSTERED ([Tremolo] ASC)
);

