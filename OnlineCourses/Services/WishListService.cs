using Data;
using Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.Extensions;
using Core.Services;
using Core.Models;

namespace OnlineCourses.Services;

public class WishListService(
    IHttpContextAccessor contextAccessor,
    OnlineCoursesDbContext context,
    IMapper mapper
    ) : IWishListService
{
    private const string key = "wishListItems";
    private readonly OnlineCoursesDbContext context = context;
    private readonly IMapper mapper = mapper;
    private readonly HttpContext? httpContext = contextAccessor.HttpContext;
    
    public void Add(int id)
    {
        var ids = GetIds();
        ids.Add(id);
        httpContext?.Session.Set(key, ids);
    }

    public IEnumerable<CourseModel> GetCourseModels()
    {
        return mapper.Map<IEnumerable<CourseModel>>(GetCourses());
    }

    public bool Delete(int id)
    {
        var ids = GetIds();
        if (!ids.Remove(id)) return false;

        httpContext?.Session.Set(key, ids);
        return true;
    }

    public void Clear()
    {
        httpContext?.Session.Remove(key);
    }

    public IEnumerable<Course> GetCourses()
    {
        var ids = GetIds();
        return context.Courses
            .Include(x => x.Category)
            .Where(x => ids.Contains(x.Id))
            .ToList();
    }

    private List<int> GetIds()
    {
        return httpContext?.Session.Get<List<int>>(key) ?? [];
    }
}
