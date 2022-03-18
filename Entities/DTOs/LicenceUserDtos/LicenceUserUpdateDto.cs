using Core.Entities;
using System;

namespace Entities.DTOs.LicenceUserDtos
{
    public class LicenceUserUpdateDto : IDto
    {
        public int LicenceUserId { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
