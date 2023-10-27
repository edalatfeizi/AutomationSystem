

namespace Automation.Domain.Interfaces.Services;

public interface IFileService
{
    Task<(string,string)> UploadFileAsync(Guid creatorUserId, IFormFile file);
    Task<(byte[], string, string)> DownloadFileAsync(string fileName);
}
