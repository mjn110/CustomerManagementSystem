using Application.DTO.Products;
using Application.Services.Products;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching products", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found" });
                }

                Frontend.Services.ProductDto wrappedProduct = new Frontend.Services.ProductDto
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Items = product.ProductItems.Select(pi => pi.ItemName).ToList()
                };

                return Ok(wrappedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching product", error = ex.Message });
            }
        }

        [HttpPost("create")]
        [IgnoreAntiforgeryToken]
        public IActionResult Create([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.CreateProduct(createProductDto);
                return Ok(new { message = "Product created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating product", error = ex.Message });
            }
        }

        [HttpPost("update")]
        [IgnoreAntiforgeryToken]
        public IActionResult Update([FromQuery] int productId, [FromBody] CreateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.UpdateProduct(updateProductDto, productId);
                return Ok(new { message = "Product updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating product", error = ex.Message });
            }
        }

        [HttpDelete("delete")]
        [IgnoreAntiforgeryToken]
        public IActionResult Delete([FromQuery] int productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                return Ok(new { message = "Product deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting product", error = ex.Message });
            }
        }
    }
}

