using Application.DTO.Products;
using Application.Services.Products;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public IActionResult Create(string Name, string Description, int Price, List<string> Items)
        {
            var createProductDto = new CreateProductDto
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Items = Items
            };

            _productService.CreateProduct(createProductDto);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(string Name, string Description, int Price, List<string> Items, int productId)
        {
            var updateProductDto = new CreateProductDto
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Items = Items
            };
            _productService.UpdateProduct(updateProductDto, productId);
            return Ok();
        }
    }
}
