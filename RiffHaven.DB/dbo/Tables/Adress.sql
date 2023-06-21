CREATE TABLE [dbo].[Adress] (
    [Id_Adress] INT           IDENTITY (1, 1) NOT NULL,
    [Street]    VARCHAR (254) NOT NULL,
    [number]    INT           NULL,
    [box]       VARCHAR (50)  NULL,
    [Zip]       INT           NOT NULL,
    [City]      VARCHAR (80)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Adress] ASC)
);

