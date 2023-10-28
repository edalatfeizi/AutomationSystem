
namespace Automation.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class DownloadsController : ControllerBase
{
    private readonly IFileService _fileService;
    public DownloadsController(IFileService fileService)
    {

        _fileService = fileService;

    }

    [HttpGet("download")]
    public async Task<IActionResult> DownloadAsync(string fileName)
    {
        var result = await _fileService.DownloadFileAsync(fileName);
        return File(result.Item1,result.Item2,result.Item3);
    }
}
