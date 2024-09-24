namespace OnlineCourses.Models;

public class LectureModel
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}
