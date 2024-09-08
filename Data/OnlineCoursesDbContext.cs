using Data.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class OnlineCoursesDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineCourses;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True";
        optionsBuilder.UseSqlServer(connStr);
    }

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
}
