using System;

namespace Customers.API.Shared.FileUpload;

public class FileUploadHandler(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHost)
{
    public async Task<FileUploadResult> UploadFileAsync(IFormFile file, string folderName)
    {
        var result = new FileUploadResult();

        if (file is null || file.Length == 0)
        {
            result.IsSuccess = false;
            result.ErrorMessage = "No file found";
            return result;
        }

        if (file.Length > 10 * 1024 * 1024)
        {
            result.IsSuccess = false;
            result.ErrorMessage = "File is too big";
            return result;
        }

        var allowedFileTypes = new[] { ".png", ".img", ".jpeg", ".jpg" };
        var fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension is null || !allowedFileTypes.Contains(fileExtension.ToLowerInvariant()))
        {
            result.IsSuccess = false;
            result.ErrorMessage = "File type not supported";
            return result;
        }

        var folder = Path.Combine(webHost.WebRootPath, folderName);

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var fullPath = Path.Combine($"{folder}/{file.FileName}");

        using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);

        var httpContext = httpContextAccessor.HttpContext;
        var fileUrl = Path.Combine($"{httpContext?.Request.Scheme}://{httpContext?.Request.Host}/{fullPath}");

        result.IsSuccess = true;
        result.FileUploadUrl = fileUrl;
        return result;

    }
}
