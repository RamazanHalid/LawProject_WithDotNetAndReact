using Core.Entities;

namespace Entities.DTOs.SmsTemplateDtos
{
    public class SmsTemplateGetDto : IDto
    {
        public int SmsTemplateId { get; set; }
        public string SmsHeader { get; set; }
        public string Message { get; set; }
    }
}
