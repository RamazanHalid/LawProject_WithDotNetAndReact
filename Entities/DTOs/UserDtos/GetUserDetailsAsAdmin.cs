using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.UserDtos
{
    public class GetUserDetailsAsAdmin : IDto
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public DateTime Date { get; set; }
        public bool IsCellPhoneApproved { get; set; }
        public bool IsEmailApproved { get; set; }
        public bool IsActive { get; set; }
        public string ProfileImage { get; set; }
    }
}
