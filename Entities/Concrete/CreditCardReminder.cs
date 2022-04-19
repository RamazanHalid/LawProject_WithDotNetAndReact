using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCardReminder : IEntity
    {
        public int Id { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public string FullName { get; set; }
        public string CreditCardNo { get; set; }
        public int LatestMonth { get; set; }
        public int LatestYear { get; set; }
        public int SecurityCode { get; set; }
    }
}
