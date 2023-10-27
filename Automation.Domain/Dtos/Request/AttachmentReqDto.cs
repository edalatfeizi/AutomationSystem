﻿
namespace Automation.Domain.Dtos.Request;

public class AttachmentReqDto
{
    public string Name { get; set; }
    public string MimeType { get; set; }
    public string URI { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string DeletedBy { get; set; } = string.Empty;
}
