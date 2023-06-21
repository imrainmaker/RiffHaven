CREATE TABLE [dbo].[Orders] (
    [Id_Orders]    INT             IDENTITY (1, 1) NOT NULL,
    [DateOrder]    DATE            NOT NULL,
    [PriceExclVAT] DECIMAL (15, 2) NOT NULL,
    [PriceVAT]     VARCHAR (50)    NOT NULL,
    [NbrProducts]  INT             NOT NULL,
    [VAT]          INT             NOT NULL,
    [Id_Adress]    INT             NOT NULL,
    [Id_Users]     INT             NOT NULL,
    [Id_Payements] INT             NOT NULL,
    [Id_Status]    INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Orders] ASC),
    FOREIGN KEY ([Id_Adress]) REFERENCES [dbo].[Adress] ([Id_Adress]),
    FOREIGN KEY ([Id_Payements]) REFERENCES [dbo].[Payements] ([Id_Payements]),
    FOREIGN KEY ([Id_Status]) REFERENCES [dbo].[Status] ([Id_Status]),
    FOREIGN KEY ([Id_Users]) REFERENCES [dbo].[Users] ([Id_Users])
);

