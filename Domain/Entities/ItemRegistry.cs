using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ItemRegistry
    {
        private static readonly IReadOnlyList<Item> _items = new Item[] { new Lettuce() };

        public static IReadOnlyList<Item> All => _items;
        public static Item? FindByName(string name) =>
            _items.FirstOrDefault(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}
