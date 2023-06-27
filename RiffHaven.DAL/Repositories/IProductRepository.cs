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
        public void AddProduct(Products product);
        public GuitarParts GetParts();
        public List<Products> GetProducts();
        public Products GetProductById(int id);
        public bool DeleteProduct(int id);
        public Products UpdateProduct(int id, Products productToUpdate);
    }
}
