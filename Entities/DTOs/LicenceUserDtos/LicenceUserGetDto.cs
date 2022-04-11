using Core.Entities;
using Entities.DTOs.LicenceDtos;
using Entities.DTOs.UserDtos;
using System;

namespace Entities.DTOs.LicenceUserDtos
{
    public class LicenceUserGetDto : IDto
    {
        public int LicenceUserId { get; set; }
        public LicenceGetDto LicenceGetDto { get; set; }
        public UserForLicenceUserGetDto User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public bool IsUserAccept { get; set; }

    }
}
