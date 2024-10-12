using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Core.Models;
using Core.Services;

namespace OnlineCourses.Controllers;

public class HomeController(ICoursesService coursesService) : Controller
{
    public IActionResult Index()
    {
        return View(coursesService.GetCourseModels());
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
