CREATE TABLE [dbo].[Products] (
    [Id_Products] INT             IDENTITY (1, 1) NOT NULL,
    [Model]       VARCHAR (254)   NOT NULL,
    [Description] VARCHAR (254)   NULL,
    [Stock]       INT             NOT NULL,
    [Price]       DECIMAL (15, 2) NOT NULL,
    [Id_Guitar]   INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Products] ASC),
    FOREIGN KEY ([Id_Guitar]) REFERENCES [dbo].[Guitar] ([Id_Guitar]),
    UNIQUE NONCLUSTERED ([Id_Guitar] ASC)
);

