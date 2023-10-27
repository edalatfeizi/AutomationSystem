using Microsoft.AspNetCore.Authorization;

namespace Automation.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IAttachmentService _attachmentService;
        public MailsController(IFileService fileService, IAttachmentService attachmentService)
        {
            _fileService = fileService;

            _attachmentService = attachmentService;

        }
        [HttpPost("send")]
        [Authorize]
        public async Task<IActionResult> SendMailAsync([FromBody] MailReqDto dto)
        {

            return Ok();

        }
        [HttpPost("attachfile")]
        [Authorize]
        public async Task<ActionResult> UploadAttachmentsAsync([FromQuery] string mailId, [FromForm] List<IFormFile> attachments)
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

                var attachment = await _attachmentService.GetById(attachmentId);


            }

            return Ok();
        }
    }
}
