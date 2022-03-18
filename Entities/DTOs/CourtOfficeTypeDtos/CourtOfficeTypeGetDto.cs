using Core.Entities;

namespace Entities.DTOs.CourtOfficeTypeDtos
{
    public class CourtOfficeTypeGetDto : IDto
    {
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeTypeName { get; set; }
    }
}
