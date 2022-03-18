using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.UserDtos
{
    public class UpdateUserDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string ProfileImage { get; set; }
        public IFormFile ProfileImageFile { get; set; } 
    }
}
