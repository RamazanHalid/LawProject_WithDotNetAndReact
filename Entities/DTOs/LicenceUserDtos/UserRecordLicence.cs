using Core.Entities;
using System;

namespace Entities.DTOs.LicenceUserDtos
{
    public class UserRecordLicence : IDto
    {
        public int UserId { get; set; }
        public string LicenceName { get; set; }
        public string LicenceOwnerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
