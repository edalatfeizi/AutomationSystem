using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Dtos.Request
{
    public class FileDto
    {
        public IFormFile File { get; set; }
    }
}
