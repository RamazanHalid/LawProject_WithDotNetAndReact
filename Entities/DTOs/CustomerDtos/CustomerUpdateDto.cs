using Core.Entities;

namespace Entities.DTOs.CustomerDtos
{
    public class CustomerUpdateDto : IDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
    }
}
