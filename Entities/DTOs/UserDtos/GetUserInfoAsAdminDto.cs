using Core.Entities;
using System;

namespace Entities.DTOs.UserDtos
{
    public class GetUserInfoAsAdminDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
