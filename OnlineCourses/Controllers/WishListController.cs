using Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCourses.Models;
using OnlineCourses.Extensions;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourses.Controllers;

public class WishListController(IMapper mapper, OnlineCoursesDbContext context) : Controller
{
    private readonly IMapper mapper = mapper;
    private readonly OnlineCoursesDbContext context = context;
    private const string key = "wishListItems";

    public IActionResult Index()
    {
        var ids = HttpContext.Session.Get<List<int>>(key) ?? [];
        var courses = context.Courses
            .Include(x => x.Category)
            .Where(x => ids.Contains(x.Id))
            .ToList();
        var model = mapper.Map<IEnumerable<CourseModel>>(courses);
        return View(model);
    }

    public IActionResult Add(int id)
    {
        var ids = HttpContext.Session.Get<List<int>>(key) ?? [];
        ids.Add(id);
        HttpContext.Session.Set(key, ids);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Remove(int id)
    {
        var ids = HttpContext.Session.Get<List<int>>(key) ?? [];
        if (!ids.Remove(id)) return NotFound();

        HttpContext.Session.Set(key, ids);
        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        HttpContext.Session.Remove(key);
        return RedirectToAction("Index");
    }
}
