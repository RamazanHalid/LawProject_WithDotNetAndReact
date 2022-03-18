using Core.Entities;

namespace Entities.DTOs.ProcessTypeDtos
{
    public class ProcessTypeGetDto : IDto
    {
        public int ProcessTypeId { get; set; }
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
