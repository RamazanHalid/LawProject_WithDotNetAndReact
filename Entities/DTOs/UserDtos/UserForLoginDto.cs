﻿using Core.Entities;

namespace Entities.DTOs.UserDtos
{
    public class UserForLoginDto : IDto
    {
        public string CellPhone { get; set; }
        public string Password { get; set; }
    }
}
