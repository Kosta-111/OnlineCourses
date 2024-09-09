using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourses.Controllers;

public class CoursesController : Controller
{
    private OnlineCoursesDbContext context = new();
    public IActionResult Index()
    {
        // load courses from db
        var courses = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .ToList();

        return View(courses);
    }

    private void LoadCategoriesAndLevels()
    {
        ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
        ViewBag.Levels = new SelectList(context.Levels.ToList(), "Id", "Name");
    }

    [HttpGet]
    public IActionResult Create()
    {
        LoadCategoriesAndLevels();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Course model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }

        context.Courses.Add(model);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var course = context.Courses.Find(id);
        if (course == null) return NotFound();

        context.Courses.Remove(course);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var course = context.Courses
            .Where(x => x.Id == id)
            .Include(x => x.Category)
            .Include(x => x.Level)
            .Include(x => x.Lectures)
            .FirstOrDefault();

        if (course == null) return NotFound();

        course.Lectures = course.Lectures.OrderBy(x => x.Number).ToList();
        return View(course);
    }
}
