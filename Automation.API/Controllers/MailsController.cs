
namespace Automation.API.Controllers;

[Route("api/v1/[controller]")]
[Authorize]
[ApiController]
public class MailsController : ControllerBase
{
    private readonly IMailService _mailService;
    private readonly IFileService _fileService;
    private readonly IMailAttachmentService _mailAttachmentService;
    private readonly IAttachmentService _attachmentService;
    
    public MailsController(IMailService mailService, IFileService fileService, IMailAttachmentService mailAttachmentService, IAttachmentService attachmentService)
    {
        _mailService = mailService;
        _fileService = fileService;
        _mailAttachmentService = mailAttachmentService;
        _attachmentService = attachmentService;
    }

    [HttpGet("filter")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<MailResDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> FilterMailsAsync([FromQuery] FilterMailsReqDto filters)
    {
        var result = await _mailService.FilterMailsAsync(filters);
        return Ok(result);
    }

    [HttpGet("inbox")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<MailResDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetIncomingMailsAsync()
    {
        var filters = new FilterMailsReqDto { To = HttpContext.GetUserEmail().ToString() };

        var result = await _mailService.FilterMailsAsync(filters);
        return Ok(result);
    }

    [HttpGet("outbox")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<MailResDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetOutcomingMailsAsync()
    {
        var filters = new FilterMailsReqDto { From = HttpContext.GetUserEmail().ToString() };
        var result = await _mailService.FilterMailsAsync(filters);
        return Ok(result);
    }

    [HttpPost("send")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<MailResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SendMailAsync([FromBody] MailAddReqDto dto)
    {
        var result = await _mailService.AddMailAsync(dto);
        return Ok(result);
    }

    [HttpPost("attachfile")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<AttachmentResDto>>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UploadAttachmentsAsync([FromQuery] Guid mailId, [FromForm] List<IFormFile> attachments)
    {
        foreach (var file in attachments)
        {
            var fileResult = await _fileService.UploadFileAsync(HttpContext.GetUserId(), file);

            var attachmentDto = new AttachmentReqDto
            {
                Name = fileResult.Item1,
                MimeType = file.ContentType,
                URI = fileResult.Item2,
                CreatedBy = HttpContext.GetUserId().ToString()
            };

            var attachmentId = await _attachmentService.AddAttachment(attachmentDto);

            await _mailAttachmentService.AddMailAttachmentAsync(mailId, attachmentId);

        }
        var result = await _mailAttachmentService.GetMailAttachmentsAsync(mailId);
        return Ok(result);
    }
}
