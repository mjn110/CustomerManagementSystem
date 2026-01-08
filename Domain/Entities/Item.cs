using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Item
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Stock { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
