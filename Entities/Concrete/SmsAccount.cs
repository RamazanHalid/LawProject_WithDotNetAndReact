using Core.Entities;

namespace Entities.Concrete
{
    public class SmsAccount : IEntity
    {
        public int SmsAccountId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int SmsCount { get; set; }
    }
}
