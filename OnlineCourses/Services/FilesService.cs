namespace OnlineCourses.Services;

public class FilesService(IWebHostEnvironment env) : IFilesService
{
    private const string folderName = "images";
    public async Task<string> SaveImage(IFormFile file)
    {
        // get new file path
        var root = env.WebRootPath;
        var name = Guid.NewGuid().ToString();
        var ext = Path.GetExtension(file.FileName);

        var relativePath = Path.Combine(folderName, name + ext);
        var fullPath = Path.Combine(root, relativePath);

        // save file content
        using var fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);
        return relativePath;
    }

    public async Task<string> EditImage(IFormFile newFile, string? oldPath)
    {
        if (oldPath is not null)
            await DeleteImage(oldPath);

        return await SaveImage(newFile);
    }

    public Task DeleteImage(string path)
    {
        string fullPath = Path.Combine(env.WebRootPath, path);

        return File.Exists(fullPath)
            ? Task.Run(() => File.Delete(fullPath))
            : Task.CompletedTask;
    }
}
