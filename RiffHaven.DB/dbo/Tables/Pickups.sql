CREATE TABLE [dbo].[Pickups] (
    [Id_Pickups] INT          IDENTITY (1, 1) NOT NULL,
    [pickup]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Pickups] ASC),
    UNIQUE NONCLUSTERED ([pickup] ASC)
);

