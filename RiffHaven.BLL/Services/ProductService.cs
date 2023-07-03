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

        public bool AddProduct(Products product)
        {
            int? idGuitar = _service.AddProduct(product);
            Directory.CreateDirectory($@"..\..\RiffHavenAngular\src\assets\Guitars\Guitar{idGuitar}");
            return idGuitar is not null ? true : false;
        }

        public bool DeleteProduct(int id)
        {
            int? idGuitar = _service.DeleteProduct(id);
            string path = $@"..\..\RiffHavenAngular\src\assets\Guitars\Guitar{idGuitar}";
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            return idGuitar is not null ? true : false;
        }

        public GuitarParts? GetParts()
        {
            GuitarParts? parts = _service.GetParts();
            return parts;
        }

        public Products? GetProductById(int id)
        {
            Products? product = _service.GetProductById(id);
            return product;
        }

        public List<Products> GetProducts()
        {
            List<Products> products = _service.GetProducts();
            return products;
        }

        public Products? UpdateProduct(int id, UpdateProductDTO product)
        {
            Products? productToUpdate = _service.GetProductById(id);
            if(productToUpdate is not null)
            {
                productToUpdate.Model = product.Model;
                productToUpdate.Description = product.Description;
                productToUpdate.Stock = product.Stock;
                productToUpdate.Price = product.Price;

                Products? productUpdated = _service.UpdateProduct(id, productToUpdate);

                return productUpdated;
            }

            return null;


        }


        public Products? UpdateGuitar(int id, UpdateGuitarDTO product)
        {
            Products? guitarToUpdate = _service.GetProductById(id);
            if (guitarToUpdate is not null)
            {
                //Modification de l'id pour atteindre la guitar depuis une page produit
                // Id_Produit != Id_Guitar
                id = guitarToUpdate.Id_Guitar;
                
                guitarToUpdate.Brand = product.Brand;
                guitarToUpdate.Style = product.Style;
                guitarToUpdate.Color = product.Color;
                guitarToUpdate.Pickup = product.Pickup;
                guitarToUpdate.Scale = product.Scale;
                guitarToUpdate.Frets = product.Frets;
                guitarToUpdate.Tremolo = product.Tremolo;
                guitarToUpdate.BodyWood = product.BodyWood;
                guitarToUpdate.NeckWood = product.NeckWood;
                guitarToUpdate.TopWood = product.TopWood;
                guitarToUpdate.FretboardWood = product.FretboardWood;



                Products guitarUpdated = _service.UpdateGuitar(id, guitarToUpdate);

                return guitarUpdated;
            }

            return null;
        }
    }
}
