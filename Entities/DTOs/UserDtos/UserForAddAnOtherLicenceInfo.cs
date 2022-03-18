using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.UserDtos
{
    public class UserForAddAnOtherLicenceInfo : IDto
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public City City { get; set; }
        public string ProfileImage { get; set; }
    }
}
