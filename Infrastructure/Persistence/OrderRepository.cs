using Application.Common.Interface.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private static readonly List<Order> _orders = new();
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public Order GetOrderById(Guid id)
    {
        return _orders.SingleOrDefault(o => o.OrderId == id);
    }

    public List<Order> GetOrders()
    {
        return _orders;
    }
}
