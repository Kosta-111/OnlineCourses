namespace Core.Models;

public class CourseModelDetailed : CourseModel
{
    public List<LectureModel> Lectures { get; set; } = [];
}
