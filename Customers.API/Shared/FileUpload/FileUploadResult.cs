using System;

namespace Customers.API.Shared.FileUpload;

public class FileUploadResult
{
    public bool IsSuccess { get; set; }
    public string? FileUploadUrl { get; set; }
    public string? ErrorMessage { get; set; }
}
