using RiffHaven.Domain.Dtos;
using RiffHaven.Domain.Entities;

namespace RiffHaven.BLL.Interfaces
{
    public interface IProductService
    {
        public bool AddProduct(Products product);
        public GuitarParts? GetParts();
        public List<Products> GetProducts();
        public Products? GetProductById(int id);
        public bool DeleteProduct(int id);
        public Products? UpdateProduct(int id, UpdateProductDTO product);
        public Products? UpdateGuitar(int id, UpdateGuitarDTO product);
        public List<Products> Filter(ProductFilterDTO filters);

    }
}
