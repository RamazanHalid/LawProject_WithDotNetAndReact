using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.User
{
    public class UserSelectsLicenceForLogin : IDto
    {
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public int LicenceId { get; set; }

    }
}
