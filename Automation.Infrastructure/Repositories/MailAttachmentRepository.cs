
namespace Automation.Infrastructure.Repositories;

public class MailAttachmentRepository : IMailAttachmentRepository
{
    private readonly AutomationDbContext _context;
    public MailAttachmentRepository(AutomationDbContext context)
    {
        _context = context;

    }

    public async Task<MailAttachment> AddMailAttachmentAsync(Guid mailId, Mail mail, Guid attachmentId, Attachment attachment)
    {
        var mailAttachment = new MailAttachment { MailId = mailId, Mail = mail, AttachmentId = attachmentId, Attachment = attachment };
        await _context.MailAttachments.AddAsync(mailAttachment);
        await _context.SaveChangesAsync();
        return mailAttachment;
    }

    public async Task<MailAttachment?> GetByMailIdAsync(Guid id)
    {
        var mailAttachment = await _context.MailAttachments.FindAsync(id);
        return mailAttachment;
    }
}
