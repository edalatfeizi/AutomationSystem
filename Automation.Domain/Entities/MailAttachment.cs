
namespace Automation.Domain.Entities;

public class MailAttachment
{
    public Guid Id { get; set; }

    public Mail Mail { get; set; }
    public Guid MailId { get; set; }

    public Attachment Attachment { get; set; }
    public Guid AttachmentId { get; set; }
}
