﻿using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.LicenceDtos
{
    public class LicenceUpdateDto : IDto
    {
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public int PersonTypeId { get; set; }
        public string BillAddress { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public string ProfilName { get; set; }
    }
}
