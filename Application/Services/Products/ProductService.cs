using Application.Common.Interface.Persistence;
using Application.DTO.Products;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Frontend.Services.ProductDto> GetAllProducts()
        {
            var result = _productRepository.GetAllProducts();
            var products = result.Select(p => new Frontend.Services.ProductDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Items = p.ProductItems?.Select(pi => pi.ItemName).ToList() ?? new List<string>()
            }).ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void CreateProduct(CreateProductDto createProductDto)
        {
            if (string.IsNullOrWhiteSpace(createProductDto.Name))
            {
                throw new ArgumentException("Product name is required");
            }

            Product product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description ?? string.Empty,
                Price = createProductDto.Price,
                ProductItems = createProductDto.Items != null && createProductDto.Items.Any()
                    ? createProductDto.Items
                        .Where(item => !string.IsNullOrWhiteSpace(item))
                        .Select(itemName => new ProductItem { ItemName = itemName })
                        .ToList()
                    : new List<ProductItem>()
            };

            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(CreateProductDto updateProductDto, int productId)
        {
            if (string.IsNullOrWhiteSpace(updateProductDto.Name))
            {
                throw new ArgumentException("Product name is required");
            }

            Product product = _productRepository.GetProductById(productId);

            if (product == null)
            {
                throw new Exception($"Product with id {productId} not found");
            }

            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description ?? string.Empty;
            product.Price = updateProductDto.Price;
            product.ProductItems = updateProductDto.Items != null && updateProductDto.Items.Any()
                    ? updateProductDto.Items
                        .Where(item => !string.IsNullOrWhiteSpace(item))
                        .Select(itemName => new ProductItem { ItemName = itemName })
                        .ToList()
                    : new List<ProductItem>();

            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            Product product = _productRepository.GetProductById(productId);

            if (product == null)
            {
                throw new Exception($"Product with id {productId} not found");
            }

            _productRepository.DeleteProduct(product);
        }
    }
}
