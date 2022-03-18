using Core.Entities;

namespace Entities.Concrete
{
    public class PersonType : IEntity
    {
        public int PersonTypeId { get; set; }
        public string PersonTypeName { get; set; }
    }
}
