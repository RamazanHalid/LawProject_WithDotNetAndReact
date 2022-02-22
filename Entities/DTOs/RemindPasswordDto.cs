using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UpdateUserPasswordDto : IDto
    {
        public string CellPhone { get; set; }
        public string SmsCode { get; set; }
        public string NewPassword{ get; set; }
    }
}
