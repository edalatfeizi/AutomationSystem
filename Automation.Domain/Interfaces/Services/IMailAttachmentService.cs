

namespace Automation.Domain.Interfaces.Services;

public interface IMailAttachmentService
{
    Task AddMailAttachmentAsync(Guid mailId,  Guid attachmentId);
    Task<ApiResponse<List<AttachmentResDto>>> GetMailAttachmentsAsync(Guid mailId);
}
