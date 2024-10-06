using Microsoft.AspNetCore.Http;

namespace Core.Services;

public interface IFilesService
{
    Task<string> SaveImage(IFormFile file);
    Task<string> EditImage(IFormFile newFile, string? oldPath);
    Task DeleteImage(string path);
}
