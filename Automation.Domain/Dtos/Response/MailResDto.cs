
namespace Automation.Domain.Dtos.Response;

public record MailResDto
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
    public Guid? RepliedTo { get; set; }
    public Guid? ForwardedFrom { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsDeleted { get; set; } 
    public string DeletedBy { get; set; }
}
