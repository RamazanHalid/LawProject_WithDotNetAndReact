using Core.Entities;

namespace Entities.DTOs.UserDtos
{
    public class UserForRegisterDto : IDto
    {
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public int CityId { get; set; }

    }
}
