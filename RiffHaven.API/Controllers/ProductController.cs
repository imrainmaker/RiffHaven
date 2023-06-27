using Microsoft.AspNetCore.Mvc;
using RiffHaven.API.Dtos;
using RiffHaven.API.Mappers;
using RiffHaven.BLL.Interfaces;
using RiffHaven.Domain.Dtos;
using RiffHaven.Domain.Entities;

namespace RiffHaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddProduct(NewProductDTO product)
        {
            _service.AddProduct(product.ToProduct());
            return Ok();
        }

        [HttpGet("Detail")]
        public IActionResult GetParts() 
        {
            GuitarParts parts = _service.GetParts();
            return Ok(parts); 
        }

        [HttpGet]

        public IActionResult GetProducts() {
            List<Products> products = _service.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public IActionResult GetProductById(int id)
        {
            Products product = _service.GetProductById(id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool delete = _service.DeleteProduct(id);
            return Ok(delete);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductDTO product)
        {
            Products productUpdated = _service.UpdateProduct(id, product);
            return Ok(productUpdated);
        }
    }
}
