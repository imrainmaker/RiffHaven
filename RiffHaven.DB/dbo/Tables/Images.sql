CREATE TABLE [dbo].[Images]
(
	[Id_Image] INT IDENTITY NOT NULL, 
	[Id_Guitar] INT NOT NULL,
	[Image_Name] VARCHAR(254) NOT NULL,
	FOREIGN KEY ([Id_Guitar]) REFERENCES [dbo].[Guitar] ([Id_Guitar]),
	CONSTRAINT UK_Image UNIQUE([Image_Name], [Id_Guitar])

)
