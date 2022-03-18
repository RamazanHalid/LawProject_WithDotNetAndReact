using Core.Entities;
using Entities.DTOs.CourtOfficeTypeDtos;

namespace Entities.DTOs.CaseStatusDtos
{
    public class CaseStatusGetDto : IDto
    {
        public int CaseStatusId { get; set; }
        public CourtOfficeTypeGetDto CourtOfficeTypeGetDto { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
