using Application.Common.Interface.Persistence;
using Application.DTO.Orders;
using Domain.Entities;

namespace Application.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public List<GetOrderDto> GetAllOrders()
    {
        return _orderRepository.GetOrders()
            .Select(order => new GetOrderDto
            {
                Id = order.OrderId,
                Name = order.Name,
                TotalAmount = order.TotalAmount,
            })
            .ToList();
    }

    public GetOrderDto GetOrderById(Guid id)
    {
        var order = _orderRepository.GetOrderById(id);

        if (order is null)
        {
            return null;
        }

        return new GetOrderDto() {
            Id = order.OrderId,
            Name = order.Name,
            TotalAmount = order.TotalAmount,
        };
    }

    public void CreateOrder(CreateOrderDto createOrderDto)
    {
        var order = new Order(){
            Name = createOrderDto.Name,
            TotalAmount = createOrderDto.TotalAmount,
        };
        _orderRepository.AddOrder(order);
    }
}
