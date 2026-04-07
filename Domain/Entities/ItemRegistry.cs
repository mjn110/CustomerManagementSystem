using Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ItemRegistry
    {
        private static readonly IReadOnlyList<Item> _items = new Item[]
        {
            new Lettuce(),
            new Pepper(),
            new Tomato(),
            new Onion(),
            new Cheese(),
            new Meat(),
            new Sauce(),
            new Bread()
        };

        public static IReadOnlyList<Item> All => _items;
        public static Item? FindByName(string name) =>
            _items.FirstOrDefault(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}
