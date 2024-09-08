using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public static class DbSeedExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
        [
            new() { Id = 1, Name = "Design" },
            new() { Id = 2, Name = "Programming" },
            new() { Id = 3, Name = "Networks" },
            new() { Id = 4, Name = "Project management" },
            new() { Id = 5, Name = "Database analyst" }
        ]);

        modelBuilder.Entity<Level>().HasData(
        [
            new() { Id = 1, Name = "Beginner" },
            new() { Id = 2, Name = "Middle" },
            new() { Id = 3, Name = "Strong middle" },
            new() { Id = 4, Name = "High" },
            new() { Id = 5, Name = "Super PRO" }
        ]);

        modelBuilder.Entity<Course>().HasData(
        [
            new() { Id = 1, Name = "Python", Description = "Super course about Python, realy!", Language = "English", LevelId = 2, IsCertificate = true, 
                CategoryId = 2, Price = 100, Discount = 10, Rating = 3.5, ImageUrl = "https://loudbench.com/wp-content/uploads/2023/02/Python-logo-696x392.png" },
            new() { Id = 2, Name = "C++", Description = "Super course about C++, realy!", Language = "English", LevelId = 3, IsCertificate = true, 
                CategoryId = 2, Price = 150, Discount = 5, Rating = 4.5, ImageUrl = "https://www.vikingsoftware.com/wp-content/uploads/2024/02/C-2.png" },
            new() { Id = 3, Name = "Data bases", Description = "Super course about Data bases, realy!", Language = "English", LevelId = 4, IsCertificate = true,
                CategoryId = 5, Price = 450, Discount = 15, Rating = 3.0, ImageUrl = "https://miro.medium.com/v2/resize:fit:640/format:webp/1*1fc2dDk1RywRv6nDw_EE_A.png" },
            new() { Id = 4, Name = "Networks security", Description = "Super course about Networks security, realy!", Language = "English", LevelId = 5, IsCertificate = true,
                CategoryId = 3, Price = 300, Discount = 10, Rating = 4.2, ImageUrl = "https://purplesec.us/wp-content/uploads/2020/11/what-is-network-security-300x239.png" },
            new() { Id = 5, Name = "Photoshop for housewifes", Description = "Super course about Photoshop, realy!", Language = "English", LevelId = 1, IsCertificate = false,
                CategoryId = 1, Price = 100, Discount = 0, Rating = 4.8, ImageUrl = "https://logos-world.net/wp-content/uploads/2020/11/Adobe-Photoshop-Logo.png" }
        ]);

        modelBuilder.Entity<Lecture>().HasData(
        [
            new() { Id = 1, Number = 1, Name = "Intro", Description = "Very interesting Intro lecture...", CourseId = 2 },
            new() { Id = 2, Number = 2, Name = "Data types and variables", Description = "Very interesting lecture about Data types and variables", CourseId = 2 },
            new() { Id = 3, Number = 3, Name = "Algorithms", Description = "Very interesting lecture about Algorithms", CourseId = 2 },
            new() { Id = 4, Number = 4, Name = "Functions", Description = "Very interesting lecture about Functions...", CourseId = 2 },
            new() { Id = 5, Number = 5, Name = "Arrays", Description = "Very interesting lecture about Arrays...", CourseId = 2 }
        ]);

        modelBuilder.Entity<Material>().HasData(
        [
            new() { Id = 1, Name = "Lesson 1. Intro to C++", Url = "./video/C/1.mp4", Duration = 95, LectureId = 1 },
            new() { Id = 2, Name = "Lesson 2. Data types", Url = "./video/C/2_1.mp4", Duration = 115, LectureId = 2 },
            new() { Id = 3, Name = "Lesson 2. Variables", Url = "./video/C/2_2.mp4", Duration = 60, LectureId = 2 },
            new() { Id = 4, Name = "Lesson 3. Algorithms", Url = "./video/C/3.mp4", Duration = 75, LectureId = 3 },
            new() { Id = 5, Name = "Lesson 4. Functions", Url = "./video/C/4.mp4", Duration = 100, LectureId = 4 }
        ]);

        modelBuilder.Entity<Student>().HasData(
        [
            new() { Id = 1, FirstName = "Ivan", LastName = "Ivanenko", Email = "ivanenko@gmail.com", Phone = "+380965800214", Country = "Ukraine",
                BirthDate = new(1990, 12, 1), Balance = 10 },
            new() { Id = 2, FirstName = "Petro", LastName = "Petrenko", Email = "petro.petrenko@gmail.com", Phone = "+380971234567", Country = "Ukraine",
                BirthDate = new(2000, 11, 2), Balance = 0 },
            new() { Id = 3, FirstName = "Oleg", LastName = "Novak", Email = "novak@gmail.com", Phone = "+380936547821", Country = "Ukraine",
                BirthDate = new(2001, 5, 8), Balance = 100 },
            new() { Id = 4, FirstName = "Olexandr", LastName = "Bondar", Email = "bondar@gmail.com", Phone = "+380671200077", Country = "Ukraine",
                BirthDate = new(2005, 1, 10), Balance = 1000 },
            new() { Id = 5, FirstName = "Taras", LastName = "Shevshenko", Email = "sheva@gmail.com", Phone = "+380509811199", Country = "Ukraine",
                BirthDate = new(1999, 7, 9), Balance = 5 }
        ]);
    }
}
