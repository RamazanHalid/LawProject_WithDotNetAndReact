using Core.Entities;

namespace Entities.DTOs.AccountActivityTypeDtos
{
    public class AccountActivityTypeUpdateDto : IDto
    {
        public int AccountActivityTypeId { get; set; }
        public string Name { get; set; }
    }
}
