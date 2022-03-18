using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class Eventt : IEntity
    {
        public int EventtId { get; set; }
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CaseeId { get; set; }
        public virtual Casee Casee { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Info { get; set; }
        public bool IsActive { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }

    }
}
