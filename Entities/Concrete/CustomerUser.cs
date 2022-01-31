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
        public int PersonTypeId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberAdd { get; set; }
        public string Fax{ get; set; }
        public string Email{ get; set; }
        public bool IsOnlineUser{ get; set; }
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public string WebSite{ get; set; }
        public bool IsActive{ get; set; }


    }
}
