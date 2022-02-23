using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class LicenceAfterLoginDto : IDto
    {
        public int LicenceId { get; set; }
        public string Image { get; set; }
        public int UserCount { get; set; }
        public PersonType PersonType { get; set; }
        public City City { get; set; }
        public string ProfilName { get; set; }
        public bool IsApproved { get; set; }
    }
}
