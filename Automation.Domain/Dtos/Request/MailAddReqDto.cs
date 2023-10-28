
namespace Automation.Domain.Dtos.Request;

public class MailAddReqDto
{ 
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public MailImediacyType ImediacyType { get; set; }
    public MailClassificationType ClassificationType { get; set; }
    public MailType MailType { get; set; }
    public Guid? RepliedTo { get; set; }
    public Guid? ForwardedFrom { get; set; }
    public string Description { get; set; }
}
