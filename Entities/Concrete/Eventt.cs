using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class Eventt : IEntity
    {
        public int EventtId { get; set; }
        public int EventTypeId { get; set; }
        public string Title{ get; set; }
        public  EventType EventType { get; set; }
        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }
        public int CaseeId { get; set; }
        public  Casee Casee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
        public string Info { get; set; }
        public bool IsActive { get; set; }
        public int CreatorId { get; set; }
        public  User Creator { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }

    }
}
