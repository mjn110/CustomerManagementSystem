using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ProductItem
    {
        public int ProductItemId { get; set; }

        public int ProductId { get; set; }

        public string ItemName { get; set; }

        public Product Product { get; set; }
    }
}
