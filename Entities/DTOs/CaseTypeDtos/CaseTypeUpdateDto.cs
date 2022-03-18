using Core.Entities;

namespace Entities.DTOs.CaseTypeDtos
{
    public class CaseTypeUpdateDto : IDto
    {
        public int CaseTypeId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
