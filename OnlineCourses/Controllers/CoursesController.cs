using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.Models;

namespace OnlineCourses.Controllers;

public class CoursesController : Controller
{
    private OnlineCoursesDbContext context = new();
    private readonly IMapper mapper;

    public CoursesController(IMapper mapper)
    {
        this.mapper = mapper;
    }

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
    public IActionResult Create(CreateCourseModel model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }

        var entity = mapper.Map<Course>(model);
        context.Courses.Add(entity);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = context.Courses.Find(id);
        if (course is null) return NotFound();

        LoadCategoriesAndLevels();
        var model = mapper.Map<EditCourseModel>(course);
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(EditCourseModel model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }

        var entity = mapper.Map<Course>(model);
        context.Courses.Update(entity);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var course = context.Courses.Find(id);
        if (course is null) return NotFound();

        context.Courses.Remove(course);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var course = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .Include(x => x.Lectures)
            .Where(x => x.Id == id)
            .FirstOrDefault();            

        if (course is null) return NotFound();

        course.Lectures = course.Lectures.OrderBy(x => x.Number).ToList();
        return View(course);
    }
}
