using Application.Common.Interface.Persistence;
using Application.DTO.Products;
using Domain.Entities;
using System;
using System.Collections.Generic;
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

        public void CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ProductItems = createProductDto.Items
                    .Select(itemName => new ProductItem { ItemName = itemName })
                    .ToList()
            };

            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(CreateProductDto updateProductDto, int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.ProductItems = updateProductDto.Items
                    .Select(itemName => new ProductItem { ItemName = itemName })
                    .ToList();
            _productRepository.UpdateProduct(product);
        }
    }
}
