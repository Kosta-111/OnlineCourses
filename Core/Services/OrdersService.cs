using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class OrdersService(
    OnlineCoursesDbContext context,
    IWishListService wishListService
    ) : IOrdersService
{
    private readonly OnlineCoursesDbContext context = context;
    public void Add(string? userId)
    {
        var order = new Order
        {
            CreationDate = DateTime.Now,
            UserId = userId!,
            Courses = wishListService.GetCourses().ToList()
        };
        context.Orders.Add(order);
        context.SaveChanges();
    }

    public List<Order> GetOrders(string? userId)
    {
        return context.Orders
            .Include(x => x.Courses)
            .Where(x => x.UserId == userId)
            .ToList();
    }
}
