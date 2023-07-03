CREATE PROCEDURE DeleteProduct
@id INT
AS
BEGIN
DECLARE @Id_Guitar INT = (SELECT Id_Guitar FROM Products WHERE Id_Products = @id);
	
	DELETE FROM Products Where Id_Products = @id;
	DELETE FROM Guitar Where Id_Guitar = @Id_Guitar;

	SELECT @Id_Guitar AS ID

END