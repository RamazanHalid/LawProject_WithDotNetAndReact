using Core.Entities;
using Entities.DTOs.UserDtos;

namespace Entities.DTOs.CaseIngonereUserDtos
{
    public class CaseIgnoreGetDto : IDto
    {
        public int CaseIgnoreUserId { get; set; }
        public UserForAddAnOtherLicenceInfo User { get; set; }
    }
}
