namespace Data.Entities;

public class Lecture : IEntity
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }

    public ICollection<Material> Materials { get; set; } = [];

    public int CourseId { get; set; }
    public Course? Course { get; set; }
}