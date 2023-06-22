using RiffHaven.BLL.Interfaces;
using RiffHaven.DAL.Repositories;
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
    }
}
