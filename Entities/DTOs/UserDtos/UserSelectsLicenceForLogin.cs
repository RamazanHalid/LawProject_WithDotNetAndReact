using Core.Entities;

namespace Entities.DTOs.UserDtos
{
    public class UserSelectsLicenceForLogin : IDto
    {
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public int LicenceId { get; set; }

    }
}
