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

        public int AddProduct(Products product)
        {
            try
            {
                string sql = "EXEC AddGuitar @Model, @Description, @Stock, @Price, @Tremolo, @Pickup, @Scale," +
                             " @Frets, @Color, @Style, @Brand, @BodyWood, @NeckWood, @TopWood, @FretboardWood";
                return _connection.QueryFirst<int>(sql, product);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }

        public int DeleteProduct(int id)
        {
            try
            {

                var parameters = new { Id = id };
                string sql = "EXEC DeleteProduct @id";

                return _connection.QueryFirst<int>(sql, parameters); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public GuitarParts? GetParts()
        {
            GuitarParts parts = new GuitarParts();
            string sql;
            // Brands
            try
            {
                sql = "SELECT Brand FROM Brands";
                parts.Brands = _connection.Query<string>(sql).ToList();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Colors
            try
            {
                sql = "SELECT Color FROM Colors";
                parts.Colors = _connection.Query<string>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Styles
            try
            {
                sql = "SELECT Style FROM Styles";
                parts.Styles = _connection.Query<string>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Pickups
            try
            {
                sql = "SELECT Pickup FROM Pickups";
                parts.Pickups = _connection.Query<string>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Tremolos
            try
            {
                sql = "SELECT Tremolo FROM Tremolo";
                parts.Tremolos = _connection.Query<string>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Woods
            try
            {
                sql = "SELECT Wood FROM Woods";
                parts.Woods = _connection.Query<string>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Scales
            try
            {
                sql = "SELECT Scale FROM Scales";
                parts.Scales = _connection.Query<int>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            // Frets
            try
            {
                sql = "SELECT Frets FROM Frets";
                parts.Frets = _connection.Query<int>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return parts;

        }

        public Products? GetProductById(int id)
        {
            try
            {
                var parameters = new { Id = id};
                string sql = "SELECT * FROM ProductsView WHERE Id_Products = @id";
                return _connection.QueryFirst<Products>(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Products> GetProducts()
        {

            string sql = "SELECT * FROM ProductsView";
            List<Products> products = _connection.Query<Products>(sql).ToList(); 
            return products;
        }

        public Products? UpdateProduct(int id, Products productToUpdate)
        {
            var parameters = new
            {
                Id = id,
                Model = productToUpdate.Model,
                Description = productToUpdate.Description,
                Stock = productToUpdate.Stock,
                Price = productToUpdate.Price
            };
            try
            {

                string sql = "UPDATE Products SET Model = @Model, Description = @Description, Stock = @Stock, Price = @Price WHERE Id_Products = @Id";
                _connection.Execute(sql, parameters);

                return productToUpdate;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Products? UpdateGuitar(int id, Products guitarToUpdate)
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

            try
            {
                string sql = "EXEC UpdateGuitar @Id_Guitar, @Tremolo, @Pickup, @Scale, @Frets, @Color, @Style, @Brand, " +
                             "@BodyWood, @NeckWood, @TopWood, @FretboardWood";
                Products guitarUpdated= _connection.QueryFirst<Products>(sql, parameters);

                return guitarUpdated is not null ? guitarUpdated : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool AddPreview(int id, string fileName)
        {
            var parameters = new { Id = id, FileName = fileName };


            try
            {
                string sql = "UPDATE GUITAR SET ImageUrl = @FileName WHERE Id_Guitar = @Id";
                int result = _connection.Execute(sql, parameters);

                return result == 1 ? true : false ;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
