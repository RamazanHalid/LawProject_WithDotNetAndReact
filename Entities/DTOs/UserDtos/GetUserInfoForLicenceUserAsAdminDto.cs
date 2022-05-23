using Core.Entities;
using System;

namespace Entities.DTOs.UserDtos
{
    public class GetUserInfoForLicenceUserAsAdminDto : IDto
    {
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public DateTime AddedDateToLicence { get; set; }
        public DateTime? EndDateLeavtFromLicence{ get; set; }
        public int RecordedLicenceId { get; set; }
        public bool IsActiveOnLicence { get; set; }
    }
}
