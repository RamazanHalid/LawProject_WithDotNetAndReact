using Core.Entities;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public string CustomerName { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public bool IsActive { get; set; }
        public virtual Casee Casee { get; set; }

    }
}
