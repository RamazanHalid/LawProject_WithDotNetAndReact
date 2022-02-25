using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class LicenceUser : IEntity
    {
        public int LicenceUserId { get; set; }
        public int LicenceId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Licence Licence { get; set; }
        public virtual User User { get; set; }

    }
}
