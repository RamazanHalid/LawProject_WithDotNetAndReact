using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EmailMultipleReciver
    {
        public List<string> Tos { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public IFormFile ContentFile { get; set; }
    }
}
