using Data.Entities;

namespace Core.Services;

public interface IOrdersService
{
    List<Order> GetOrders(string? userId);
    void AddAll(string? userId);
    bool Add(string? userId, int courseId);
}
