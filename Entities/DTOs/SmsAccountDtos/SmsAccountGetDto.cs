using Core.Entities;

namespace Entities.DTOs.SmsAccountDtos
{
    public class SmsAccountGetDto : IDto
    {
        public int SmsAccountId { get; set; }
        public int SmsCount { get; set; }
    }
}
