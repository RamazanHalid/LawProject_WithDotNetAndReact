using Core.Entities;

namespace Entities.DTOs.TaskTypeDtos
{
    public class TaskTypeAddDto : IDto
    {
        public string TaskTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
