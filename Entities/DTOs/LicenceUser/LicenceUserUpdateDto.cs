using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.LicenceUser
{
    public class LicenceUserUpdateDto : IDto
    {
        public int LicenceUserId { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
