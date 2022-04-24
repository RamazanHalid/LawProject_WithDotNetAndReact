using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.SmsTemplateDtos
{
    public class SmsTemplateAddDto : IDto
    {
        public string SmsHeader { get; set; }
        public string Message { get; set; }
    }
}
