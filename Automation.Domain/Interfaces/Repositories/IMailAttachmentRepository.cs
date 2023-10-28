

namespace Automation.Domain.Interfaces.Repositories;

public interface IMailAttachmentRepository
{
    Task<List<MailAttachment>> GetByMailIdAsync(Guid id);
    Task<MailAttachment> AddMailAttachmentAsync(Guid mailId, Mail mail, Guid attachmentId, Attachment attachment);

}
