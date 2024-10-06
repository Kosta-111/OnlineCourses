using Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Core.Models;

namespace OnlineCourses.Controllers;

public class HomeController(IMapper mapper, OnlineCoursesDbContext context) : Controller
{
    private readonly IMapper mapper = mapper;
    private readonly OnlineCoursesDbContext context = context;

    public IActionResult Index()
    {
        // ... working with db ...
        var courses = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .ToList();

        // ~/Home/Index.cshtml
        var model = mapper.Map<IEnumerable<CourseModel>>(courses);
        return View(model);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
