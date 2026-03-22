using Domain.Entities;

namespace Application.Common.Interface.Persistence
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        //Item GetItemById(int id);
        List<Item> GetItems();
    }
}
