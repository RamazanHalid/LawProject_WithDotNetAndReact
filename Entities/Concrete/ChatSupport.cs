using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class ChatSupport : IEntity
    {
        public int ChatSupportId { get; set; }
        public bool IsAnswer { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool DoesItRead { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
