CREATE PROCEDURE [dbo].[AddGuitar]
	@Model VARCHAR (254),
	@Description VARCHAR (254),
	@Stock INT,
	@Price DECIMAL,
	@Tremolo VARCHAR (50),
	@Pickup VARCHAR (50),
	@Scale INT,
	@Frets INT,
	@Color VARCHAR (50),
	@Style VARCHAR (50), 
	@Brand VARCHAR (50),
	@BodyWood VARCHAR (50), 
	@NeckWood VARCHAR (50), 
	@TopWood VARCHAR (50),
	@FretboardWood VARCHAR (50)
AS
BEGIN
	-- Ajout infos produits --
	IF NOT EXISTS (SELECT 1 FROM Products WHERE Model = @Model)
	BEGIN
		INSERT INTO Products (Model, Description, Stock, Price)
		VALUES (@Model, @Description, @Stock, @Price)
	END

	-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Pickup --
	IF NOT EXISTS (SELECT 1 FROM Pickups WHERE pickup = @Pickup)
	BEGIN
		INSERT INTO Pickups (pickup)
		VALUES (@Pickup)
	END

		-- Ajout Scale --
	IF NOT EXISTS (SELECT 1 FROM Scales WHERE Scale = @Scale)
	BEGIN
		INSERT INTO Scales (Scale)
		VALUES (@Scale)
	END

		-- Ajout Frets --
	IF NOT EXISTS (SELECT 1 FROM Frets WHERE Frets = @Frets)
	BEGIN
		INSERT INTO Frets (Frets)
		VALUES (@Frets)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

		-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)
	END

END
