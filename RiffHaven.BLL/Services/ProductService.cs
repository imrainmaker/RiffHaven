using RiffHaven.BLL.Interfaces;
using RiffHaven.DAL.Repositories;
using RiffHaven.Domain.Dtos;
using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _service;

        public ProductService(IProductRepository service)
        {
            _service = service;
        }

        public void AddProduct(Products product)
        {
            _service.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _service.DeleteProduct(id);
        }

        public GuitarParts GetParts()
        {
            GuitarParts parts = _service.GetParts();
            return parts;
        }

        public Products GetProductById(int id)
        {
            Products product = _service.GetProductById(id);
            return product;
        }

        public List<Products> GetProducts()
        {
            List<Products> products = _service.GetProducts();
            return products;
        }

        public Products UpdateProduct(int id, UpdateProductDTO product)
        {
            Products productToUpdate = _service.GetProductById(id);
            if(productToUpdate is not null)
            {
                productToUpdate.Model = product.Model;
                productToUpdate.Description = product.Description;
                productToUpdate.Stock = product.Stock;
                productToUpdate.Price = product.Price;

                _service.UpdateProduct(id, productToUpdate);

            }

            return productToUpdate is not null ? productToUpdate : null;

        }
    }
}
