using Core.Entities;

namespace Entities.DTOs.CaseStatusDtos
{
    public class CaseStatusAddDto : IDto
    {
        public int CourtOfficeTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
