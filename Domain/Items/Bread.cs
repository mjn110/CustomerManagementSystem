using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Items
{
    public sealed class Bread : Item
    {
        public Bread() : base("Bread", "Soft toasted bread bun") { }
    }
}
