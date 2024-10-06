using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCourses.Controllers;

public class WishListController(IWishListService wishListService) : Controller
{
    public IActionResult Index()
    {
        return View(wishListService.GetCourseModels());
    }

    public IActionResult Add(int id)
    {
        wishListService.Add(id);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Remove(int id)
    {
        return wishListService.Delete(id)
            ? RedirectToAction("Index")
            : NotFound();
    }

    public IActionResult Clear()
    {
        wishListService.Clear();
        return RedirectToAction("Index");
    }
}
