
using Core.Entities;
using Entities.DTOs.LicenceUser;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class UserOwnAndRelationalLicencesDto : IDto
    {
        public int UserId { get; set; }
        public List<LicenceAfterLoginDto> UserOwnLicences { get; set; }
        public List<LicenceUserGetDto> UserRealtionalLicences { get; set; }
    }
}
