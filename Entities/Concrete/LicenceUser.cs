using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class LicenceUser : IEntity
    {
        public int LicenceUserId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence{ get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
        public bool IsActive { get; set; }

    }
}
