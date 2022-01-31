﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleTr { get; set; }
        public string TitleEn { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsApproved{ get; set; }
        public bool IsActive{ get; set; }
        public bool IsAdmin { get; set; }
        public string SmsCode { get; set; }
        public string ProfileImage { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

    }
}