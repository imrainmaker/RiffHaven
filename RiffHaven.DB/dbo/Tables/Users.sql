CREATE TABLE [dbo].[Users] (
    [Id_Users]  INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  VARCHAR (80)   NOT NULL,
    [FirstName] VARCHAR (80)   NOT NULL,
    [Email]     VARCHAR (100)  NOT NULL,
    [Phone]     VARCHAR (20)   NULL,
    [Role]      BIT            NOT NULL,
    [pwd]       VARBINARY (64) NOT NULL,
    [Salt]      VARCHAR (36)   NOT NULL,
    [Id_Adress] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id_Users] ASC),
    FOREIGN KEY ([Id_Adress]) REFERENCES [dbo].[Adress] ([Id_Adress]),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Salt] ASC)
);

