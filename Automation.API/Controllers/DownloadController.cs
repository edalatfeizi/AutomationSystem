
namespace Automation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DownloadController : ControllerBase
{
    private readonly IFileService _fileService;
    public DownloadController(IFileService fileService)
    {

        _fileService = fileService;

    }

    [HttpGet("download")]
    [Authorize]
    public async Task<IActionResult> DownloadAsync(string fileName)
    {
        var result = await _fileService.DownloadFileAsync(fileName);
        return File(result.Item1,result.Item2,result.Item3);
    }
}
