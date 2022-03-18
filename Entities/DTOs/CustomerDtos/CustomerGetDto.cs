using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.CustomerDtos
{
    public class CustomerGetDto : IDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public bool IsActive { get; set; }
    }
}
