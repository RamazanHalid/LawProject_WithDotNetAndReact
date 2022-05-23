using Core.Entities;
using Entities.DTOs.CourtOfficeTypeDtos;

namespace Entities.DTOs.CaseTypeDtos
{
    public class CaseTypeGetDto : IDto
    {
        public int CaseTypeId { get; set; }
        public string Description { get; set; }
        public CourtOfficeTypeGetDto CourtOfficeTypeGetDto { get; set; }
        public bool IsActive { get; set; }
    }
}
