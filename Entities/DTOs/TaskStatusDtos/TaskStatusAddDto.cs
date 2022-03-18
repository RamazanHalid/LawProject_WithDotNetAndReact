using Core.Entities;

namespace Entities.DTOs.TaskStatusDtos
{
    public class TaskStatusAddDto : IDto
    {
        public string TaskStatusName { get; set; }
    }
}
