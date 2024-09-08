namespace Data.Entities;

public class Level : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; } = [];

    public override string ToString()
    {
        return Name;
    }
}