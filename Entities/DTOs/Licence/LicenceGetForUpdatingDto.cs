using Core.Entities;
using Entities.Concrete; 
namespace Entities.DTOs.Licence
{
    public class LicenceGetForUpdatingDto : IDto
    {
        public virtual PersonType PersonType { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public City City { get; set; }
        public string ProfilName { get; set; }
      }
}
