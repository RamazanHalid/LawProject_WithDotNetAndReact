using Core.Entities;

namespace Entities.DTOs.ChatSupportDtos
{
    public class ChatSupportAddAsAdmin : IDto
    {
        public int LicenceId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
