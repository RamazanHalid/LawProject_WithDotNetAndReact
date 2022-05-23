using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class LicenceFilterAsAdmin
    {
        public int UserId { get; set; }
        public string ProfileName { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
    }
}
