
namespace Automation.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        public FileRepository()
        {
            
        }
        public async Task<(string, string)> UploadFileAsync(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var fileName = $"{file.FileName}_{DateTime.UtcNow.Ticks}_{fileInfo.Extension}";
            var filePath = FileCommons.GetFilePath(fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return (fileName,filePath);
        }
        public async Task<(byte[],string,string)> DownloadFileAsync(string fileName)
        {
            var filePath = FileCommons.GetFilePath(fileName);
            var provider = new FileExtensionContentTypeProvider();

            if(!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var fileBytes = await File.ReadAllBytesAsync(filePath);
            return (fileBytes, contentType, Path.GetFileName(filePath));

        }

     
    }
}
