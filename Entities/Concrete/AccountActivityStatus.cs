using Core.Entities;

namespace Entities.Concrete
{
    public class AccountActivityStatus : IEntity
    {
        public int AccountActivityStatusId { get; set; }
        public string Name { get; set; }
    }
}
