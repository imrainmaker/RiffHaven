CREATE PROCEDURE UpdatePasswd
    @Id int,
    @ActualPasswd NVARCHAR(20),
    @NewPasswd NVARCHAR(20)
AS
BEGIN
    DECLARE @Pepper NVARCHAR(128) = '%0Pepper0%'


    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE Id_Users = @id
            AND pwd = HASHBYTES('SHA2_512', salt + @ActualPasswd + @Pepper)
    )
    BEGIN

        UPDATE Users
        SET pwd = HASHBYTES('SHA2_512', salt + @NewPasswd + @Pepper)
        WHERE Id_Users = @id;
    END
END