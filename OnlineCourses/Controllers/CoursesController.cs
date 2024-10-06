using Data;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Core.Models;

namespace OnlineCourses.Controllers;

public class CoursesController(
    IMapper mapper, 
    IFilesService filesService, 
    OnlineCoursesDbContext context) : Controller
{
    private readonly IMapper mapper = mapper;
    private readonly OnlineCoursesDbContext context = context;
    private readonly IFilesService filesService = filesService;

    public IActionResult Index()
    {
        // load courses from db
        var courses = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .ToList();

        var model = mapper.Map<List<CourseModel>>(courses);
        return View(model);
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
    public async Task<IActionResult> Create(CourseModelCreate model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }

        var entity = mapper.Map<Course>(model);

        // save file to server
        if (model.Image is not null)
            entity.ImageUrl = await filesService.SaveImage(model.Image);

        context.Courses.Add(entity);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var entity = context.Courses.Find(id);
        if (entity is null) return NotFound();

        LoadCategoriesAndLevels();
        var model = mapper.Map<CourseModelEdit>(entity);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CourseModelEdit model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }

        var entity = mapper.Map<Course>(model);

        // rewrite file on server
        if (model.Image is not null)
            entity.ImageUrl = await filesService.EditImage(model.Image, entity.ImageUrl);

        context.Courses.Update(entity);
        context.SaveChanges();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var entity = context.Courses.Find(id);
        if (entity is null) return NotFound();

        context.Courses.Remove(entity);
        context.SaveChanges();

        if (entity.ImageUrl is not null)
            await filesService.DeleteImage(entity.ImageUrl);

        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var entity = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .Include(x => x.Lectures.OrderBy(x => x.Number))
            .Where(x => x.Id == id)
            .FirstOrDefault();            

        if (entity is null) return NotFound();

        var model = mapper.Map<CourseModelDetailed>(entity);
        return View(model);
    }
}
