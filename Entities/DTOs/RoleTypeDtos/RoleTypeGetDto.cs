using Entities.DTOs.CourtOfficeTypeDtos;

namespace Entities.DTOs.RoleTypeDtos
{
    public class RoleTypeGetDto
    {
        public int RoleTypeId { get; set; }
         public CourtOfficeTypeGetDto CourtOfficeType { get; set; }
        public string RoleName { get; set; }
    }
}
