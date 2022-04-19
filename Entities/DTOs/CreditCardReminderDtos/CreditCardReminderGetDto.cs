using Core.Entities;

namespace Entities.DTOs.CreditCardReminderDtos
{
    public class CreditCardReminderGetDto : IDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
