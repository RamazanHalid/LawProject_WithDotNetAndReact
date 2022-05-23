using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public static IEnumerable<object> Claims { get; set; }
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public int UserProfileAvatarId { get; set; }
        public string Title { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsCellPhoneApproved { get; set; }
        public bool IsEmailApproved { get; set; }
        public Guid ApproveGuid { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string SmsCode { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
