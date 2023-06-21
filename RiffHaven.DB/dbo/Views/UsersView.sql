CREATE VIEW UsersView AS
SELECT U.Id_Users, U.LastName, U.FirstName, U.Email, U.Phone, A.Street, A.Number, A.Box, A.Zip, A.City
FROM Users U
JOIN Adress A ON U.Id_Adress = A.Id_Adress;
