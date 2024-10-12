using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnlineCourses.Controllers;

[Authorize]
public class OrdersController(IOrdersService ordersService) : Controller
{
    private string? CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

    public IActionResult Index()
    {
        return View(ordersService.GetOrders(CurrentUserId));
    }

    public IActionResult Add()
    {
        ordersService.Add(CurrentUserId);
        return RedirectToAction("Index");
    }
}
