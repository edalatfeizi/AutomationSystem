
namespace Automation.Domain.Entities;

public class Attachment
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MimeType { get; set; }
    public string URI { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public bool DeletedBy { get; set;}
}
