

namespace Automation.Domain.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;
    public FileService(IFileRepository repository)
    {
        _fileRepository = repository;

    }
    public Task<(byte[], string, string)> DownloadFileAsync(string fileName)
    {
        var result = _fileRepository.DownloadFileAsync(fileName);
        return result;
    }

    public async Task<(string,string)> UploadFileAsync(Guid creatorUserId, IFormFile file)
    {
        var result = await _fileRepository.UploadFileAsync(file);
        return result;
    }
}
