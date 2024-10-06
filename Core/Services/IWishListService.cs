using Core.Models;
using Data.Entities;

namespace Core.Services;

public interface IWishListService
{
    void Add(int id);
    bool Delete(int id);
    void Clear();
    IEnumerable<Course> GetCourses();
    IEnumerable<CourseModel> GetCourseModels();
}
