namespace Entities.DTOs.TaskTypeDtos
{
    public class TaskTypeGetDto
    {
        public int TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
