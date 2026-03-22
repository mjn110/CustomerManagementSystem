using Application.Common.Interface.Persistence;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly CustomerOrderManagementContext _context;
        public ProductRepository(CustomerOrderManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.ProductItems).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.ProductItems).FirstOrDefault(p => p.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}