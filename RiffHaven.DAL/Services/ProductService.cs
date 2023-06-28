using Dapper;
using RiffHaven.DAL.Repositories;
using RiffHaven.Domain.Entities;
using System.Data;

namespace RiffHaven.DAL.Services
{
    public class ProductService : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void AddProduct(Products product)
        {
            string sql = "EXEC AddGuitar @Model, @Description, @Stock, @Price, @Tremolo, @Pickup, @Scale," +
                         " @Frets, @Color, @Style, @Brand, @BodyWood, @NeckWood, @TopWood, @FretboardWood";
            _connection.Execute(sql, product);
        }

        public bool DeleteProduct(int id)
        {
            var parameters = new { Id = id };
            string sql = "EXEC DeleteProduct @id";

            int result = _connection.Execute(sql, parameters); 
            return result == 2 ? true : false;

        }

        public GuitarParts GetParts()
        {
            GuitarParts parts = new GuitarParts();
            string sql;
            // Brands
            sql = "SELECT Brand FROM Brands";
            parts.Brands = _connection.Query<string>(sql).ToList();

            // Colors
            sql = "SELECT Color FROM Colors";
            parts.Colors = _connection.Query<string>(sql).ToList();

            // Styles
            sql = "SELECT Style FROM Styles";
            parts.Styles = _connection.Query<string>(sql).ToList();

            // Pickups
            sql = "SELECT Pickup FROM Pickups";
            parts.Pickups = _connection.Query<string>(sql).ToList();

            // Tremolos
            sql = "SELECT Tremolo FROM Tremolo";
            parts.Tremolos = _connection.Query<string>(sql).ToList();

            // Woods
            sql = "SELECT Wood FROM Woods";
            parts.Woods = _connection.Query<string>(sql).ToList();

            // Scales
            sql = "SELECT Scale FROM Scales";
            parts.Scales = _connection.Query<int>(sql).ToList();

            // Frets
            sql = "SELECT Frets FROM Frets";
            parts.Frets = _connection.Query<int>(sql).ToList();

            return parts;

        }

        public Products GetProductById(int id)
        {
            var parameters = new { Id = id};
            string sql = "SELECT * FROM ProductsView WHERE Id_Products = @id";
            return _connection.QueryFirst<Products>(sql, parameters);
        }

        public List<Products> GetProducts()
        {
            string sql = "SELECT * FROM ProductsView";
            List<Products> products = _connection.Query<Products>(sql).ToList(); 
            return products;
        }

        public Products UpdateProduct(int id, Products productToUpdate)
        {
            var parameters = new
            {
                Id = id,
                Model = productToUpdate.Model,
                Description = productToUpdate.Description,
                Stock = productToUpdate.Stock,
                Price = productToUpdate.Price
            };

            string sql = "UPDATE Products SET Model = @Model, Description = @Description, Stock = @Stock, Price = @Price WHERE Id_Products = @Id";
            _connection.Execute(sql, parameters);

            return productToUpdate;
        }

        public Products UpdateGuitar(int id, Products guitarToUpdate)
        {
            var parameters = new
            {
                Id_Guitar = id,
                Brand = guitarToUpdate.Brand,
                Style = guitarToUpdate.Style,
                Color = guitarToUpdate.Color,
                Pickup = guitarToUpdate.Pickup,
                Scale = guitarToUpdate.Scale,
                Frets = guitarToUpdate.Frets,
                Tremolo = guitarToUpdate.Tremolo,
                BodyWood = guitarToUpdate.BodyWood,
                NeckWood = guitarToUpdate.NeckWood,
                TopWood = guitarToUpdate.TopWood,
                FretboardWood = guitarToUpdate.FretboardWood
            };

            string sql = "EXEC UpdateGuitar @Id_Guitar, @Tremolo, @Pickup, @Scale, @Frets, @Color, @Style, @Brand, " +
                         "@BodyWood, @NeckWood, @TopWood, @FretboardWood";
            Products guitarUpdated= _connection.QueryFirst<Products>(sql, parameters);

            return guitarUpdated is not null ? guitarUpdated : null;
        }
    }
}
