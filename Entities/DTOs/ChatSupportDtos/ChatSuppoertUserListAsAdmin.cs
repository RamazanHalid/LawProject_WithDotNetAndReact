using Core.Entities;
using System;

namespace Entities.DTOs.ChatSupportDtos
{
    public class ChatSuppoertUserListAsAdmin : IDto
    {
        public int ChatSupportId { get; set; }
        public bool IsAnswer { get; set; }
        public int LicenceId { get; set; }
        public string LicenceName { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public bool DoesItRead { get; set; }
        public DateTime Date { get; set; }
        public int UnreadMessageCount { get; set; }
    }
}
