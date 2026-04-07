using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Items
{
    public sealed class Cheese : Item
    {
        public Cheese() : base("Cheese", "Melted cheddar cheese") { }
    }
}
