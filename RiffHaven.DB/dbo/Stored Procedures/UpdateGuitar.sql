CREATE PROCEDURE [dbo].[UpdateGuitar]
	@Id_Guitar INT,
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
	DECLARE @Id_Tremolo INT
	DECLARE @Id_Pickup INT
	DECLARE @Id_Scale INT
	DECLARE @Id_Frets INT
	DECLARE @Id_Color INT
	DECLARE @Id_Style INT 
	DECLARE @Id_Brand INT
	DECLARE @Id_BodyWood INT
	DECLARE @Id_NeckWood INT
	DECLARE @Id_TopWood INT
	DECLARE @Id_FretboardWood INT
	


	-- Ajout Tremolo --
	IF NOT EXISTS (SELECT 1 FROM Tremolo WHERE Tremolo = @Tremolo)
	BEGIN
		INSERT INTO Tremolo (Tremolo)
		VALUES (@Tremolo)

		SET @Id_Tremolo = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Tremolo = (SELECT Id_Tremolo FROM Tremolo WHERE Tremolo = @Tremolo)
	END

	-- Ajout Pickup --
	IF NOT EXISTS (SELECT 1 FROM Pickups WHERE pickup = @Pickup)
	BEGIN
		INSERT INTO Pickups (pickup)
		VALUES (@Pickup)

		SET @Id_Pickup = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Pickup = (SELECT Id_Pickups FROM Pickups WHERE pickup = @Pickup)
	END

	-- Ajout Scale --
	IF NOT EXISTS (SELECT 1 FROM Scales WHERE Scale = @Scale)
	BEGIN
		INSERT INTO Scales (Scale)
		VALUES (@Scale)

		SET @Id_Scale = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Scale = (SELECT Id_Scales FROM Scales WHERE Scale = @Scale)
	END

	-- Ajout Frets --
	IF NOT EXISTS (SELECT 1 FROM Frets WHERE Frets = @Frets)
	BEGIN
		INSERT INTO Frets (Frets)
		VALUES (@Frets)

		SET @Id_Frets = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Frets = (SELECT Id_Frets FROM Frets WHERE Frets = @Frets)
	END

	-- Ajout Color --
	IF NOT EXISTS (SELECT 1 FROM Colors WHERE Color = @Color)
	BEGIN
		INSERT INTO Colors(Color)
		VALUES (@Color)

		SET @Id_Color = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Color = (SELECT Id_Colors FROM Colors WHERE Color = @Color)
	END

		-- Ajout Style --
	IF NOT EXISTS (SELECT 1 FROM Styles WHERE Style = @Style)
	BEGIN
		INSERT INTO Styles (Style)
		VALUES (@Style)

		SET @Id_Style = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Style = (SELECT Id_Styles FROM Styles WHERE Style = @Style)
	END

		-- Ajout Brand --
	IF NOT EXISTS (SELECT 1 FROM Brands WHERE Brand = @Brand)
	BEGIN
		INSERT INTO Brands(Brand)
		VALUES (@Brand)

		SET @Id_Brand = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_Brand = (SELECT Id_Brands FROM Brands WHERE Brand = @Brand)
	END

	-- Ajout Wood --
	IF NOT EXISTS (SELECT 1 FROM Woods WHERE wood = @BodyWood)
	BEGIN
		INSERT INTO Woods (wood)
		VALUES (@BodyWood)

		SET @Id_BodyWood = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_BodyWood = (SELECT Id_Woods FROM Woods WHERE wood = @BodyWood)
	END

	-- Ajout Wood --
	IF NOT EXISTS (SELECT 1 FROM Woods WHERE wood = @TopWood)
	BEGIN
		INSERT INTO Woods (wood)
		VALUES (@TopWood)

		SET @Id_TopWood = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_TopWood = (SELECT Id_Woods FROM Woods WHERE wood = @TopWood)
	END

	-- Ajout Wood --
	IF NOT EXISTS (SELECT 1 FROM Woods WHERE wood = @NeckWood)
	BEGIN
		INSERT INTO Woods (wood)
		VALUES (@NeckWood)

		SET @Id_NeckWood = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_NeckWood = (SELECT Id_Woods FROM Woods WHERE wood = @NeckWood)
	END

	-- Ajout Wood --
	IF NOT EXISTS (SELECT 1 FROM Woods WHERE wood = @FretboardWood)
	BEGIN
		INSERT INTO Woods (wood)
		VALUES (@FretboardWood)

		SET @Id_FretboardWood = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Id_FretboardWood = (SELECT Id_Woods FROM Woods WHERE wood = @FretboardWood)
	END

	-- Update de la guitare--
	Update Guitar SET Id_Tremolo = @Id_Tremolo, Id_Pickups = @Id_Pickup, Id_Scales = @Id_Scale, Id_Frets = @Id_Frets, 
					  Id_Colors = @Id_Color, Id_Styles = @Id_Style, Id_Brands = @Id_Brand, Body = @Id_BodyWood, 
					  Neck = @Id_NeckWood, [Top] = @Id_TopWood, Fretboards = @Id_FretboardWood
	WHERE Id_Guitar = @Id_Guitar

	Select * FROM ProductsView WHERE Id_Guitar = @Id_Guitar


END
