using Core.Entities;
using System; 
namespace Entities.Concrete
{
    public class Licence : IEntity
    {
        public int LicenceId { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public int Gb { get; set; }
        public int SmsAccountId { get; set; }
        public int SmsCount { get; set; }
        public int UserCount { get; set; }
        public int PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
 
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string ProfilName { get; set; }
        public bool IsApproved { get; set; }
        public float Balance { get; set; }
        public DateTime LastBillDate { get; set; }
    }
}
