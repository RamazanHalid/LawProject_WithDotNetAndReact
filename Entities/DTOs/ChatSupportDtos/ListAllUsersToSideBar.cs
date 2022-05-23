using Core.Entities;
using System;

namespace Entities.DTOs.ChatSupportDtos
{
    public class ListAllUsersToSideBar : IDto
    {
        public int LicenceId { get; set; }
        public string LicenceProfileName { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserProfileImage{ get; set; }
        public int MessageCount { get; set; }
        public DateTime Date { get; set; }
     }
}
