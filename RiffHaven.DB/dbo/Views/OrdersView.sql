CREATE VIEW OrdersView AS
SELECT O.Id_Orders, O.DateOrder, O.PriceExclVAT, O.PriceVAT, O.NbrProducts, O.VAT, U.Id_Users, U.LastName, U.FirstName, U.Email, U.Phone, A.Street, A.Number, A.Box, A.Zip, A.City, P.Id_Products, P.Model, P.Description, P.Stock, P.Price
FROM Orders O
JOIN Users U ON O.Id_Users = U.Id_Users
JOIN Adress A ON O.Id_Adress = A.Id_Adress
JOIN OrdersProducts OP ON O.Id_Orders = OP.Id_Orders
JOIN Products P ON OP.Id_Products = P.Id_Products;
