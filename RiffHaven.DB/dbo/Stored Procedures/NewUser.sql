CREATE PROCEDURE NewUser
    @mail NVARCHAR(100),
    @nom NVARCHAR(80),
    @prenom NVARCHAR(80),
    @passwd NVARCHAR(50)
AS
BEGIN
    DECLARE @salt VARCHAR(36)
    DECLARE @Pepper NVARCHAR(128) = '%0Pepper0%'

    SET @salt = CONVERT(VARCHAR(36), NEWID())

    DECLARE @hashedPasswd VARBINARY(64)
    SET @hashedPasswd = HASHBYTES('SHA2_512', @salt + @passwd + @Pepper)

    INSERT INTO Users (LastName, FirstName, Email,Role, pwd, Salt)
    VALUES (@nom, @prenom, @mail,0, @hashedPasswd, @salt)
END
