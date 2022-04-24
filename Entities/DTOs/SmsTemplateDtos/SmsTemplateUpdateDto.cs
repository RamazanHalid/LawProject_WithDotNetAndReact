using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.SmsTemplateDtos
{
    public class SmsTemplateUpdateDto : IDto
    {
        public int SmsTemplateId { get; set; }
        public string SmsHeader { get; set; }
        public string Message { get; set; }

    }
}
