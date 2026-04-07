using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Items
{
    public sealed class Meat : Item
    {
        public Meat() : base("Meat", "Grilled beef patty") { }
    }
}
