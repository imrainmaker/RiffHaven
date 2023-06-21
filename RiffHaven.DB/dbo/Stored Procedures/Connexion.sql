
CREATE PROCEDURE Connexion
    @mail NVARCHAR(100),
    @passwd NVARCHAR(50)
AS
BEGIN
    DECLARE @Pepper NVARCHAR(128) = '%0Pepper0%'

    SELECT Id_Users , LastName , FirstName, Email
    FROM Users
    WHERE Email = @mail AND pwd = HASHBYTES('SHA2_512', Salt + @passwd + @Pepper);
END
