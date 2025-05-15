using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Pinko.Helpers.Extentions;

public static class FileExtention
{
    public static string CreateFile(this IFormFile file, string webRootPath, string folderName)
    {
        if(!file.IsValidFile()) return string.Empty;
        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string path = Path.Combine(webRootPath, folderName);
        using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }
        return fileName;
    }

    public static string UpdateFile(this IFormFile file, string webRootPath, string folderName, string oldUrl)
    {
        if(!file.IsValidFile()) return string.Empty;
        RemoveFile(Path.Combine(webRootPath, folderName, oldUrl));
        return file.CreateFile(webRootPath, folderName);
    }

    public static void RemoveFile(string path)
    {
        if (path is null) return;
        System.IO.File.Delete(path);
    }

    public static bool IsValidFile(this IFormFile file)
    {
        if (file is null) return false;
        if (file.Length > 2000000 &&  file.Length == 0) return false;
        if(!file.ContentType.Contains("image")) return false;

        return true;
    }
}
