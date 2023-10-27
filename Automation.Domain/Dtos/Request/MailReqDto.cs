using Microsoft.AspNetCore.Http;

namespace Automation.Domain.Dtos.Request;

public class MailReqDto
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
