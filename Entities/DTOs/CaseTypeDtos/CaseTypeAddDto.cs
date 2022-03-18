using Core.Entities;

namespace Entities.DTOs.CaseTypeDtos
{
    public class CaseTypeAddDto : IDto
    {
        public int CourtOfficeTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
