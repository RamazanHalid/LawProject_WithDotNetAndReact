using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerUser : IEntity
    {
        public int CustomerUserId { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public int PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }


    }
}
