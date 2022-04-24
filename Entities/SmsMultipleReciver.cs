using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SmsMultipleReciver
    {
        public List<string> Tos { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
