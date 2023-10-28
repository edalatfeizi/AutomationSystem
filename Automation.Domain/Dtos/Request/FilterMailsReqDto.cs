using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Dtos.Request
{
    public class FilterMailsReqDto
    {
        public int? MailNumber { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public MailImediacyType? ImediacyType { get; set; }
        public MailClassificationType? ClassificationType { get; set; }
        public MailStatus? MailStatus { get; set; }
        public MailType? MailType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
