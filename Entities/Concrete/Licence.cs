using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Licence : IEntity
    {
        public int LicenceId { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
        public DateTime StartDate { get; set; }
        public float Gb { get; set; }
        public int SmsAccountId { get; set; }
        public int PersonTypeId { get; set; }
        public  PersonType PersonType { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public  City City { get; set; }
        public string ProfilName { get; set; }
        public bool IsActive { get; set; }
        public float Balance { get; set; }
    }
}
