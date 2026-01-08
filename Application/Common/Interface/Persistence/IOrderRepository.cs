using Domain.Entities;

namespace Application.Common.Interface.Persistence;

public interface IOrderRepository
{
    void AddOrder(Order order);
    Order GetOrderById(Guid id);
    List<Order> GetOrders();
}
