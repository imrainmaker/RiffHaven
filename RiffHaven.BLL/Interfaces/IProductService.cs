using RiffHaven.Domain.Dtos.ProductDTO;
using RiffHaven.Domain.Entities;

namespace RiffHaven.BLL.Interfaces
{
    public interface IProductService
    {
        public int? AddProduct(Products product);
        public GuitarParts? GetParts();
        public List<Products> GetProducts();
        public Products? GetProductById(int id);
        public bool DeleteProduct(int id);
        public Products? UpdateProduct(int id, UpdateProductDTO product);
        public Products? UpdateGuitar(int id, UpdateGuitarDTO product);
        public List<Products> Filter(ProductFilterDTO filters);
        public string? AddPreview(int id, string fileName);
        

    }
}
