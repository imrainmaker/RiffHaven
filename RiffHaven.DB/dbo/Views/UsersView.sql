CREATE VIEW UsersView AS
SELECT U.Id_Users, U.LastName, U.FirstName, U.Email, U.Phone,U.Role, A.Street, A.Number, A.Box, A.Zip, A.City
FROM Users U
LEFT JOIN Adress A ON U.Id_Adress = A.Id_Adress;
