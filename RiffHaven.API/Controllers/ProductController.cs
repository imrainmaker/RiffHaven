using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiffHaven.BLL.Interfaces;
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
        public IActionResult AddProduct(Products product)
        {
            _service.AddProduct(product);
            return Ok();
        }
    }
}
