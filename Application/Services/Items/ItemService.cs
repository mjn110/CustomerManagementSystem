using Application.Common.Interface.Persistence;
using Application.DTO.Items;
using Application.DTO.Orders;
using Domain.Entities;

namespace Application.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public List<GetItemDto> GetAllItems()
        {
            return _itemRepository.GetItems()
                .Select(order => new GetItemDto
                {
                    Id = order.ItemId,
                    Name = order.Name,
                    Price = order.Price,
                    Stock = order.Stock
                })
                .ToList();
        }

        public GetItemDto GetItemById(Guid id)
        {
            var order = _itemRepository.GetItemById(id);

            if (order is null)
            {
                return null;
            }

            return new GetItemDto()
            {
                Id = order.ItemId,
                Name = order.Name,
                Price = order.Price,
                Stock = order.Stock
            };
        }

        public void CreateItem(CreateItemDto createItemDto)
        {
            var item = new Item()
            {
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                Stock = createItemDto.Stock
            };

            _itemRepository.AddItem(item);
        }
    }
}
