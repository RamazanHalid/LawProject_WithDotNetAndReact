using Core.Entities;
using System;

namespace Entities.DTOs.ChatSupportDtos
{
    public class ChatSupportListAsUser : IDto
    {
        public int ChatSupportId { get; set; }
        public bool IsAnswer { get; set; }
        public bool DoesItRead { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
