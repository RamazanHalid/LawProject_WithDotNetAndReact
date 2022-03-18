using Core.Entities;

namespace Entities.Concrete
{
    public class OrderType : IEntity
    {
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }
    }
}
