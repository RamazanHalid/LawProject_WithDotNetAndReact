using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public string CustomerName { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public bool IsActive { get; set; }
    }
}
