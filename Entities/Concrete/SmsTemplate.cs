using Core.Entities;

namespace Entities.Concrete
{
    public class SmsTemplate : IEntity
    {
        public int SmsTemplateId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public string SmsHeader { get; set; }
        public string Message { get; set; }
        public int IsActive { get; set; }
    }
}
