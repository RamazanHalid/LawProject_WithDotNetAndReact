using Core.Entities;

namespace Entities.Concrete
{
    public class RoleType : IEntity
    {
        public int RoleTypeId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public virtual CourtOfficeType CourtOfficeType { get; set; }
        public string RoleName { get; set; }
    }
}
