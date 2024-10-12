using Data.Entities;

namespace Core.Services;

public interface IOrdersService
{
    List<Order> GetOrders(string? userId);
    void Add(string? userId);
}
