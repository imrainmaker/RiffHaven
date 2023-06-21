CREATE TABLE [dbo].[OrdersProducts] (
    [Id_Products] INT NOT NULL,
    [Id_Orders]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Products] ASC, [Id_Orders] ASC),
    FOREIGN KEY ([Id_Orders]) REFERENCES [dbo].[Orders] ([Id_Orders]),
    FOREIGN KEY ([Id_Products]) REFERENCES [dbo].[Products] ([Id_Products])
);

