using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ApprovingUserDto : IDto
    {
        public string CellPhone { get; set; }
        public string SmsCode { get; set; }
    }
}
