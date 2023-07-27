using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.DAL.Repositories
{
    public interface IProductRepository
    {
        public int AddProduct(Products product);
        public GuitarParts? GetParts();
        public List<Products> GetProducts();
        public Products? GetProductById(int id);
        public int DeleteProduct(int id);
        public Products? UpdateProduct(int id, Products productToUpdate);
        public Products? UpdateGuitar(int id, Products GuitarToUpdate);
        public string? AddPreview(int id, string fileName);
    }
}
