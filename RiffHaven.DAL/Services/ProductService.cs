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
    }
}
