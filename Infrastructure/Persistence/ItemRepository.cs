using Application.Common.Interface.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ItemRepository : IItemRepository
    {
        private static readonly List<Item> _items = new();
        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public Item GetItemById(Guid id)
        {
            return _items.SingleOrDefault(o => o.ItemId == id);
        }

        public List<Item> GetItems()
        {
            return _items;
        }
    }
}
