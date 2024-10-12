using AutoMapper;
using Core.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class CoursesService(
    OnlineCoursesDbContext context,
    IMapper mapper,
    IFilesService filesService
    ) : ICoursesService
{
    private readonly OnlineCoursesDbContext context = context;
    private readonly IFilesService filesService = filesService;
    private readonly IMapper mapper = mapper;

    public List<Category> Categories => context.Categories.ToList();
    public List<Level> Levels => context.Levels.ToList();

    public async Task Create(CourseModelCreate model)
    {
        var entity = mapper.Map<Course>(model);

        // save file to server
        if (model.Image is not null)
            entity.ImageUrl = await filesService.SaveImage(model.Image);

        context.Courses.Add(entity);
        context.SaveChanges();
    }

    public List<CourseModel> GetCourseModels()
    {
        return mapper.Map<List<CourseModel>>(GetCourses());
    }

    public async Task<bool> Delete(int id)
    {
        var entity = context.Courses.Find(id);
        if (entity is null) return false;

        context.Courses.Remove(entity);
        context.SaveChanges();

        if (entity.ImageUrl is not null)
            await filesService.DeleteImage(entity.ImageUrl);
        return true;
    }

    public async Task Edit(CourseModelEdit model)
    {
        var entity = mapper.Map<Course>(model);

        // rewrite file on server
        if (model.Image is not null)
            entity.ImageUrl = await filesService.EditImage(model.Image, entity.ImageUrl);

        context.Courses.Update(entity);
        context.SaveChanges();
    }

    public CourseModelEdit? GetModelEdit(int id)
    {
        var entity = context.Courses.Find(id);
        return entity is null 
            ? null
            : mapper.Map<CourseModelEdit>(entity);
    }

    public CourseModelDetailed? GetModelDetailed(int id)
    {
        var entity = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .Include(x => x.Lectures.OrderBy(x => x.Number))
            .Where(x => x.Id == id)
            .FirstOrDefault();

        return entity is null
            ? null
            : mapper.Map<CourseModelDetailed>(entity);
    }

    public List<Course> GetCourses()
    {
        return context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .ToList();
    }
}
