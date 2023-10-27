
namespace Automation.Infrastructure.Repositories;

public class AttachmentRepository : IAttachmentRepository
{
    private readonly AutomationDbContext _context;
    public AttachmentRepository(AutomationDbContext context)
    {
        _context = context;
    }

    public async Task<Attachment> AddAttachment(Attachment attachment)
    {
        await _context.Attachments.AddAsync(attachment);
        await _context.SaveChangesAsync();
        return attachment;
    }

    public async Task<bool?> DeleteAttachment(Guid deletedByUserId, Guid attachmentId)
    {
        var attachment = await _context.Attachments.Where(x => x.Id == attachmentId).FirstOrDefaultAsync();
        if(attachment == null)
            return null;

        attachment.DeletedBy = deletedByUserId.ToString();
        attachment.IsDeleted = true;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Attachment?> GetByCreatorId(Guid creatorUserId)
    {
        var attachment = await _context.Attachments.Where(x => x.CreatedBy == creatorUserId.ToString()).FirstOrDefaultAsync();

        return attachment;
    }

    public async Task<Attachment?> GetById(Guid id)
    {
        var attachment = await _context.Attachments.Where(x => x.Id == id).FirstOrDefaultAsync();

        return attachment;
    }
}
