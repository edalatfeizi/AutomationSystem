

namespace Automation.Infrastructure.Repositories;

public class MailRepository : IMailRepository
{
    private readonly AutomationDbContext _context;
    public MailRepository(AutomationDbContext context)
    {
        _context = context;
    }
    public async Task<Mail> AddMailAsync(Mail mail)
    {
       var newMail = await _context.Mails.AddAsync(mail);
        await _context.SaveChangesAsync();
        return mail;
    }

    public async Task<bool> DeleteMailAsync(Guid mailId, Guid deletedByUserId)
    {
        var mail = await _context.Mails.SingleAsync(x => x.Id == mailId);
        mail.IsDeleted = true;
        mail.DeletedBy = deletedByUserId.ToString();
        return true;
    }

    public async Task<List<Mail>> FilterMailsAsync(int? mailNumber = null, string? from = null, string? to = null,
                                string? subject = null, string? body = null, MailImediacyType? mailImediacyType = null, MailClassificationType? mailClassificationType = null,
                                MailStatus? mailStatus = null, MailType? mailType = null, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var query = _context.Mails.AsQueryable();
        if (mailNumber != null)
            query = query.Where(x => x.MailNumber == mailNumber);

        if (from != null)
            query = query.Where(x => x.From == from);

        if (to != null)
            query = query.Where(x => x.To == to);

        if (subject != null)
            query = query.Where(x => x.Subject.Contains(subject));

        if (body != null)
            query = query.Where(x => x.Body.Contains(body));

        if (mailImediacyType != null)
            query = query.Where(x => x.ImediacyType == mailImediacyType);

        if (mailClassificationType != null)
            query = query.Where(x => x.ClassificationType == mailClassificationType);

        if (mailStatus != null)
            query = query.Where(x => x.MailStatus == mailStatus);

        if (mailType != null)
            query = query.Where(x => x.MailType == mailType);

        if (fromDate != null)
            query = query.Where(x => x.CreatedOn >= fromDate);

        if (toDate != null)
            query = query.Where(x => x.CreatedOn <= fromDate);

        query = query.Where(x => x.IsDeleted == false);

        var mails = await query.AsSplitQuery().ToListAsync();

        return mails;
    }

    public async Task<Mail?> GetMailByIdAsync(Guid mailId)
    {
        var mail = await _context.Mails.Where(x => x.Id == mailId).FirstOrDefaultAsync();
        return mail;
    }


    public async Task<int> GetLastMailNumberAsync()
    {
        var lastMail = await _context.Mails.OrderByDescending(x => x.MailNumber).FirstOrDefaultAsync();
        return lastMail != null ? lastMail.MailNumber : 0;
    }
}
