using AutoMapper;
using Data.Entities;
using OnlineCourses.Models;

namespace OnlineCourses.MapperProfiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<CreateCourseModel, Course>();
        CreateMap<EditCourseModel, Course>();
        CreateMap<Course, EditCourseModel>();
    }
}
