
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

    public async Task<List<MailAttachment>> GetByMailIdAsync(Guid id)
    {
        var mailAttachments = await _context.MailAttachments.Where(x => x.MailId == id).ToListAsync();
        return mailAttachments;
    }
}
