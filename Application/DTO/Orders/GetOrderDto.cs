using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Orders
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalAmount { get; set; }
    }
}
