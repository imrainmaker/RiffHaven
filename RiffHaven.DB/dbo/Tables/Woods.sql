CREATE TABLE [dbo].[Woods] (
    [Id_Woods] INT          IDENTITY (1, 1) NOT NULL,
    [wood]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Woods] ASC),
    UNIQUE NONCLUSTERED ([wood] ASC)
);

