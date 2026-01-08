using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Orders
{
    public class CreateOrderDto
    {
        public string Name { get; set; }
        public int TotalAmount { get; set; }
    }
}
