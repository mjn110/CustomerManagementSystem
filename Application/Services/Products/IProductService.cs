using Application.DTO.Products;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Products
{
    public interface IProductService
    {
        IEnumerable<Frontend.Services.ProductDto> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(CreateProductDto createProductDto);
        void UpdateProduct(CreateProductDto updateProductDto, int productId);
        void DeleteProduct(int productId);
    }
}
