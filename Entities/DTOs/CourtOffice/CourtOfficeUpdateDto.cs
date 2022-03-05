using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.CourtOffice
{
    public class CourtOfficeUpdateDto
    {
        public int CourtOfficeId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public string CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
