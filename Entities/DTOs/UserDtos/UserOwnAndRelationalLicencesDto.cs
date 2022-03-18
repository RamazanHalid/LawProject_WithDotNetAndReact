
using Core.Entities;
using Entities.DTOs.LicenceDtos;
using Entities.DTOs.LicenceUserDtos;
using System.Collections.Generic;

namespace Entities.DTOs.UserDtos
{
    public class UserOwnAndRelationalLicencesDto : IDto
    {
        public int UserId { get; set; }
        public List<LicenceAfterLoginDto> UserOwnLicences { get; set; }
        public List<LicenceUserGetDto> UserRealtionalLicences { get; set; }
    }
}
