using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; }
        public int LicenceId { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerName { get; set; }
        public bool IsReference{ get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public bool IsActive{ get; set; }
        

    }
}
