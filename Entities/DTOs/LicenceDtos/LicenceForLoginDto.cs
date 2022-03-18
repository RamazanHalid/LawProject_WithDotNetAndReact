using Core.Entities;
using Entities.Concrete;
using System;

namespace Entities.DTOs.LicenceDtos
{
    public class LicenceAfterLoginDto : IDto
    {
        public int LicenceId { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public PersonType PersonType { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string ProfilName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime LastBillDate { get; set; }

    }
}
