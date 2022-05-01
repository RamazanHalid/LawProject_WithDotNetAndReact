using Core.Entities;
using Entities.Concrete;
using System;

namespace Entities.DTOs.UserDtos
{
    public class GetUserInfoDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public string ProfileImage { get; set; }
        public DateTime Date { get; set; }
    }
}
