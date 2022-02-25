using Core.Entities;
using Entities.DTOs.User;
using System;

namespace Entities.DTOs.LicenceUser
{
    public class LicenceUserGetDto : IDto
    {
        public int LicenceUserId { get; set; }
        public LicenceGetDto LicenceGetDto { get; set; }
        public UserForLicenceUserGetDto User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
