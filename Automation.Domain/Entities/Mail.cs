
namespace Automation.Domain.Entities;

public class Mail
{
    public Guid Id { get; set; }
    public int MailNumber { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public MailImediacyType ImediacyType { get; set; }
    public MailClassificationType ClassificationType { get; set; }
    public MailStatus MailStatus { get; set; }
    public MailType MailType { get; set; }

    [ForeignKey("RepliedToMail")]
    public Guid? RepliedTo { get; set; }
    public Mail? RepliedToMail { get; set; }

    [ForeignKey("ForwardedFromMail")]
    public Guid? ForwardedFrom { get; set; }
    public Mail? ForwardedFromMail { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public string DeletedBy { get; set; } = string.Empty;
}
