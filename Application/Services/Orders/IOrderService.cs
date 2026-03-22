using Application.DTO.Orders;

namespace Application.Services.Orders;
public interface IOrderService
{
    public List<GetOrderDto> GetAllOrders();

    public GetOrderDto GetOrderById(int id);

    public void CreateOrder(CreateOrderDto createOrderDto);
}
