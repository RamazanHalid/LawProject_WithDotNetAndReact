using Core.Entities;

namespace Entities.Concrete
{
    public class AccountActivityType : IEntity
    {
        public int AccountActivityTypeId { get; set; }
        public string Name { get; set; }
    }
}
