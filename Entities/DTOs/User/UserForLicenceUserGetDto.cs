using Core.Entities;

namespace Entities.DTOs.User
{
    public class UserForLicenceUserGetDto : IDto
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleTr { get; set; }
        public string TitleEn { get; set; }
        public int CityId { get; set; }
        public string ProfileImage { get; set; }
    }
}
