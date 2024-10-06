using Data;
using Data.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace OnlineCourses.Controllers;

[Authorize]
public class OrdersController(
    OnlineCoursesDbContext context,
    IWishListService wishListService
    ) : Controller
{
    private string? CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

    public IActionResult Index()
    {
        var orders = context.Orders
                        .Include(x => x.Courses)
                        .Where(x => x.UserId == CurrentUserId)
                        .ToList();
        return View(orders);
    }

    public IActionResult Add()
    {
        var order = new Order
        {
            CreationDate = DateTime.Now,
            UserId = CurrentUserId!,
            Courses = wishListService.GetCourses().ToList()
        };

        context.Orders.Add(order);
        context.SaveChanges();

        return RedirectToAction("Index");
    }
}
