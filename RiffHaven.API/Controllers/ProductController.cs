﻿using Microsoft.AspNetCore.Mvc;
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
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
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
            Products? product = _service.GetProductById(id);
            return product is not null ? Ok(product) : BadRequest();
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Products? productUpdated = _service.UpdateProduct(id, product);
            return product is not null ? Ok(productUpdated) : BadRequest();
        }

        [HttpPatch("Detail/{id}")]
        public IActionResult UpdateGuitar(int id, UpdateGuitarDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Products? productUpdated = _service.UpdateGuitar(id, product);
            return product is not null ? Ok(productUpdated) : BadRequest();
        }

        [HttpPost("Upload")]
        public IActionResult UploadImage()
        {
            HttpRequest req = HttpContext.Request;
            if (req is not null)
            {
                foreach (var file in req.Form.Files)
                {
                    string fileName = file.FileName;
                    if (!Directory.Exists("upload")) Directory.CreateDirectory("upload");

                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload/", fileName);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Filter")]
        public IActionResult Filter(ProductFilterDTO filters) 
        {
            List<Products> products = _service.Filter(filters);
            return Ok(products);
        }
    }
}
