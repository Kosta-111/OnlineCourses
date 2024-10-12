using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using OnlineCourses.Extensions;

namespace OnlineCourses.Controllers;

public class CoursesController(ICoursesService coursesService) : Controller
{
    public IActionResult Index()
    {
        return View(coursesService.GetCourseModels());
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpGet]
    public IActionResult Create()
    {
        LoadCategoriesAndLevels();
        return View();
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpPost]
    public async Task<IActionResult> Create(CourseModelCreate model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }
        await coursesService.Create(model);
        return RedirectToAction("Index");
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var model = coursesService.GetModelEdit(id);
        if (model is null) return NotFound();

        LoadCategoriesAndLevels();
        return View(model);
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpPost]
    public async Task<IActionResult> Edit(CourseModelEdit model)
    {
        if (!ModelState.IsValid)
        {
            LoadCategoriesAndLevels();
            return View(model);
        }
        await coursesService.Edit(model);
        return RedirectToAction("Index");
    }

    [Authorize(Roles = Roles.ADMIN)]
    public async Task<IActionResult> Delete(int id)
    {
        return await coursesService.Delete(id)
            ? RedirectToAction("Index")
            : NotFound();
    }

    public IActionResult Details(int id)
    {
        var model = coursesService.GetModelDetailed(id);

        return model is not null
            ? View(model)
            : NotFound();
    }

    private void LoadCategoriesAndLevels()
    {
        ViewBag.Categories = new SelectList(coursesService.Categories, "Id", "Name");
        ViewBag.Levels = new SelectList(coursesService.Levels, "Id", "Name");
    }
}
