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
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            int? guitarId = _service.AddProduct(product.ToProduct());
            return Ok(guitarId);
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

        [HttpPost("Upload/{id}")]
        public IActionResult UploadImage(int id, List<IFormFile> files)
        {
            bool added = false;
            string folderPath = $@"..\..\RiffHavenAngular\src\assets\Guitars\Guitar{id}\";
            if (files is not null)
            {
                foreach (var file in files)
                {
                    string fileName = file.FileName;

                    if(fileName.ToLower() == "preview.jpg" || fileName.ToLower() == "preview.jpeg")
                    {
                        _service.AddPreview(id, fileName);
                        added = true;
                    }
                    string filePath = Path.Combine(folderPath, fileName);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                }

                if (!added)
                {
                    _service.AddPreview(id, files[0].FileName);
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
