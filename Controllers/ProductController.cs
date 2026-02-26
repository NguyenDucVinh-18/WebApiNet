using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiNet.Data;
using WebApiNet.Dto;

namespace WebApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductController(MyDBContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var listProduct = _context.Products.ToList();
            return Ok(listProduct);
        }

        [HttpGet("id")]
        public IActionResult getById(int id){
            var product = _context.Products.SingleOrDefault(p => p.productId == id);
            if(product != null)
            {
                return Ok();
            } else
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public IActionResult create(ProductDto productDto)
        {
            try
            {
                var product = new Product
                {
                    productName = productDto.productName,
                    price = productDto.price,
                    CategoryId = productDto.categoryId,
                };

                _context.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult update(int id, ProductDto productDto)
        {
            var product = _context.Products.SingleOrDefault(p => p.productId == id);
            if (product != null)
            {
                product.productName = productDto.productName;
                product.price = productDto.price;
                product.CategoryId = productDto.categoryId;
                _context.SaveChanges();
                return Ok(product);
            } else
            {
                return NotFound();
            }
        }


    }
}
