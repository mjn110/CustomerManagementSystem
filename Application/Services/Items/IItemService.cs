using Application.DTO.Items;

namespace Application.Services.Items
{
    public interface IItemService
    {
        public List<GetItemDto> GetAllItems();

        public GetItemDto GetItemById(Guid id);

        public void CreateItem(CreateItemDto createOrderDto);
    }
}
