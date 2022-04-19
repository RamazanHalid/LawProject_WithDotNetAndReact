using Core.Entities;

namespace Entities.DTOs.CreditCardReminderDtos
{
    public class CreditCardReminderAddDto : IDto
    {
        public string FullName { get; set; }
        public string CreditCardNo { get; set; }
        public int LatestMonth { get; set; }
        public int LatestYear { get; set; }
        public int SecurityCode { get; set; }
    }
}
