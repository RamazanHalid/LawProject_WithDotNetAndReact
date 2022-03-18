using Core.Entities;

namespace Entities.DTOs.CaseStatusDtos
{
    public class CaseStatusUpdateDto : IDto
    {
        public int CaseStatusId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
