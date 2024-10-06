using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class CourseModelCreate
{
    [Required, MinLength(2), MaxLength(50)]
    public string Name { get; set; } = null!;

    public IFormFile? Image { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    [Required, MinLength(2), MaxLength(50)]
    public string Language { get; set; } = null!;

    [Range(0, (double)decimal.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, 100)]
    public int Discount { get; set; }

    [Range(0, 5)]
    public double Rating { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Level is required!")]
    public int LevelId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Category is required!")]
    public int CategoryId { get; set; }
    public bool IsCertificate { get; set; }
}
