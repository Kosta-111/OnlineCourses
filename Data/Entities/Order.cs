namespace Data.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<Course> Courses { get; set; } = [];
}
