


namespace Automation.Domain.Interfaces.Repositories;

public interface IFileRepository
{
    Task<(string, string)> UploadFileAsync(IFormFile file);
    Task<(byte[],string,string)> DownloadFileAsync(string fileName);
}
