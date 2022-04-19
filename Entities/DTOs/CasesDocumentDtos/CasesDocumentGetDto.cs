using Core.Entities;
using Entities.DTOs.CaseeDtos;
using Entities.DTOs.UserDtos;

namespace Entities.DTOs.CasesDocumentDtos
{
    public class CasesDocumentGetDto : IDto
    {
        public int CaseDocumentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string DocumentPath { get; set; }
        public UserForLicenceUserGetDto Creator { get; set; }
        public CaseeGetDto Casee { get; set; }

    }
}
