using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class LicenceUser : IEntity
    {
        public int LicenceUserId { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }
        public int UserId { get; set; }
        public  User User2 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsUserAccept { get; set; }

    }
}
