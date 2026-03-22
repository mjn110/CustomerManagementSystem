using Application.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Products
{
    public interface IProductService
    {
        void CreateProduct(CreateProductDto createProductDto);
        void UpdateProduct(CreateProductDto updateProductDto, int productId);
    }
}
