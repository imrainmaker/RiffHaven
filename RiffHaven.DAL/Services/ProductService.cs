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
            string sql = "EXEC AddGuitar @Model, @Description, @Stock, @Price, @Brands, @Tremolo, @Pickup, @Scale," +
                         " @Frets, @Color, @Style, @Brand, @BodyWood, @NeckWood, @TopWood, @FretboardWood";
            _connection.Execute(sql, product);
        }
    }
}
