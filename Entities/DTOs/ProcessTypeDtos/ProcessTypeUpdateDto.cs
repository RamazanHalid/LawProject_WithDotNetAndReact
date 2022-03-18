using Core.Entities;

namespace Entities.DTOs.ProcessTypeDtos
{
    public class ProcessTypeUpdateDto : IDto
    {
        public int ProcessTypeId { get; set; }
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
