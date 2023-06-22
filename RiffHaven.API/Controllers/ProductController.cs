using Microsoft.AspNetCore.Mvc;
using RiffHaven.API.Dtos;
using RiffHaven.API.Mappers;
using RiffHaven.BLL.Interfaces;

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
    }
}
