using Core.Entities;

namespace Entities.DTOs.TaskTypeDtos
{
    public class TaskTypeUpdateDto : IDto
    {
        public int TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
