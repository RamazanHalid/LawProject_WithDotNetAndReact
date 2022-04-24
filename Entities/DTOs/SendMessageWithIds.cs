using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SendMessageWithIds
    {
        public List<int> Ids { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
