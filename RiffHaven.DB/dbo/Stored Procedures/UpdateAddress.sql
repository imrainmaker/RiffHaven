CREATE PROCEDURE UpdateAddress
    @Id INT,
    @Street VARCHAR(254),
    @Number INT,
    @Box VARCHAR(50),
    @Zip INT,
    @City VARCHAR(80)
AS
BEGIN
    DECLARE @Id_Address INT


    SELECT @Id_Address = Id_Adress FROM Users WHERE Id_Users = @Id

    IF @Id_Address IS NULL
    BEGIN
  
        INSERT INTO Adress (Street, Number, Box, Zip, City)
        VALUES (@Street, @Number, @Box, @Zip, @City)

        SET @Id_Address = SCOPE_IDENTITY()

        UPDATE USERS SET Id_Adress = @Id_Address WHERE Id_Users = @Id
    END
    ELSE
    BEGIN
  
        UPDATE ADRESS
        SET Street = @Street, Number = @Number, Box = @Box, Zip = @Zip, City = @City 
        WHERE Id_Adress = @Id_Address
    END
END
