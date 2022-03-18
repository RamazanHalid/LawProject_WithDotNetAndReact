using Core.Entities;

namespace Entities.Concrete
{
    public class TaskStatus : IEntity
    {
        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }
    }
}
