namespace OnlineCourses.Models;

public class CourseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string Language { get; set; } = null!;
    public decimal Price { get; set; }
    public int Discount { get; set; }
    public double Rating { get; set; }
    public bool IsCertificate { get; set; }
    public string LevelName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
}
