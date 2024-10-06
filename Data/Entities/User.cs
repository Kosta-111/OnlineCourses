using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public class User : IdentityUser
{
    //custom properties...
    public DateTime? BirthDate { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
