using AutoMapper;
using Core.Models;
using Data.Entities;

namespace Core.MapperProfiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        //course
        CreateMap<CourseModelCreate, Course>();
        CreateMap<CourseModelEdit, Course>();
        CreateMap<Course, CourseModelEdit>();
        CreateMap<Course, CourseModel>();
        CreateMap<Course, CourseModelDetailed>();

        //lecture
        CreateMap<Lecture, LectureModel>();
    }
}
