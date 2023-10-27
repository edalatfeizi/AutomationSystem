

namespace Automation.Domain.Interfaces.Repositories;

public interface IMailAttachmentRepository
{
    Task<MailAttachment?> GetByMailIdAsync(Guid id);
    Task<MailAttachment> AddMailAttachmentAsync(Guid mailId, Mail mail, Guid attachmentId, Attachment attachment);

}
