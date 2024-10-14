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
    public void AddAll(string? userId)
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

    public bool Add(string? userId, int courseId)
    {
        var course = context.Courses.Find(courseId);
        if (course is null) return false;

        var order = new Order
        {
            CreationDate = DateTime.Now,
            UserId = userId!,
            Courses = [ course ]
        };
        context.Orders.Add(order);
        context.SaveChanges();
        return true;
    }

    public List<Order> GetOrders(string? userId)
    {
        return context.Orders
            .Include(x => x.Courses)
            .Where(x => x.UserId == userId)
            .ToList();
    }
}
