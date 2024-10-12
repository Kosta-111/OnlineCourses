using Core.Models;
using Data.Entities;

namespace Core.Services;

public interface ICoursesService
{
    List<Category> Categories { get; }
    List<Level> Levels { get; }

    Task Create(CourseModelCreate model);
    CourseModelEdit? GetModelEdit(int id);
    CourseModelDetailed? GetModelDetailed(int id);
    Task Edit(CourseModelEdit model);
    Task<bool> Delete(int id);
    List<Course> GetCourses();
    List<CourseModel> GetCourseModels();
}
