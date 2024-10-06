using Data.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data;

public class OnlineCoursesDbContext : IdentityDbContext<User>
{
    public OnlineCoursesDbContext() { }
    public OnlineCoursesDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Seed();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Order> Orders { get; set; }
}
