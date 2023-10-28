
namespace Automation.Domain.Interfaces.Repositories;

public interface IMailRepository
{
    Task<Mail> AddMailAsync(Mail mail);
    Task<bool> DeleteMailAsync(Guid mailId, Guid deletedByUserId);
    Task<Mail?> GetMailByIdAsync(Guid mailId);
    Task<List<Mail>> FilterMailsAsync(int? mailNumber = null, string? from = null, string? to = null,
                                string? subject = null, string? body = null, MailImediacyType? mailImediacyType = null, MailClassificationType? mailClassificationType = null,
                                MailStatus? mailStatus = null, MailType? mailType = null, DateTime? fromDate = null, DateTime? toDate = null);
    Task<int> GetLastMailNumberAsync();
}
