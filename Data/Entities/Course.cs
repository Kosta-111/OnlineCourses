namespace Data.Entities;

public class Course : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string Language { get; set; }
    public decimal Price { get; set; }
    public int Discount { get; set; }
    public double Rating { get; set; }
    public bool IsCertificate { get; set; }

    public ICollection<Lecture> Lectures { get; set; } = [];
    public ICollection<Student> Students { get; set; } = [];

    public int LevelId { get; set; }
    public Level Level { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Category.Name})";
    }
}
