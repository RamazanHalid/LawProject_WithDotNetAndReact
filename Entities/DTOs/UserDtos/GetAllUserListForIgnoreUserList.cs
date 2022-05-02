using Core.Entities;

namespace Entities.DTOs.UserDtos
{
    public class GetAllUserListForIgnoreUserList: IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ProfileImage { get; set; }
    }
}
