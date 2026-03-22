using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public List<string> Items { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
