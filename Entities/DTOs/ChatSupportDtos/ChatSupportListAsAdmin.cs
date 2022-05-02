using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;

namespace Entities.DTOs.ChatSupportDtos
{
    public class ChatSupportListAsAdmin : IDto
    {
        public int ChatSupportId { get; set; }
        public bool IsAnswer { get; set; }
        public Licence Licence { get; set; }
        public User User { get; set; }
        public bool DoesItRead { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

    }
}
