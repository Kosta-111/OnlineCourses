namespace Data.Entities;

public class Student : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Country { get; set; }
    public decimal Balance { get; set; }
    public DateOnly? BirthDate { get; set; }

    public ICollection<Course> Courses { get; set; } = [];
}