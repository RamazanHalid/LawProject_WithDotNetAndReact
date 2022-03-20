using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerUser : IEntity
    {
        public int CustomerUserId { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }
        public int PersonTypeId { get; set; }
        public  PersonType PersonType { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public  City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }


    }
}
