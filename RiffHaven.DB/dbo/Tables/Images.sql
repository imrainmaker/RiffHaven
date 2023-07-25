CREATE TABLE [dbo].[Images] (
    [Id_Image]   INT           IDENTITY (1, 1) NOT NULL,
    [Id_Guitar]  INT           NOT NULL,
    [Image_Name] VARCHAR (254) NULL,
    FOREIGN KEY ([Id_Guitar]) REFERENCES [dbo].[Guitar] ([Id_Guitar]),
    CONSTRAINT [UK_Image] UNIQUE NONCLUSTERED ([Image_Name] ASC, [Id_Guitar] ASC)
);

