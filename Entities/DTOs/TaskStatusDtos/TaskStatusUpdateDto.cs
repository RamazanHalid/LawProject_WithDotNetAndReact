using Core.Entities;

namespace Entities.DTOs.TaskStatusDtos
{
    public class TaskStatusUpdateDto : IDto
    {
        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }

    }
}
