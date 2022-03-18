using Core.Entities;

namespace Entities.Concrete
{
    public class EventType : IEntity
    {
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
    }
}
