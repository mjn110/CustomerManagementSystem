using Domain.Entities;

namespace Application.Common.Interface.Persistence
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        Item GetItemById(Guid id);
        List<Item> GetItems();
    }
}
