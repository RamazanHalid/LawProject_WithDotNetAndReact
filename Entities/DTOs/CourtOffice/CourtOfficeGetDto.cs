using Entities.Concrete;
using Entities.DTOs.CourtOfficeType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.CourtOffice
{
    public class CourtOfficeGetDto
    {
        public int CourtOfficeId { get; set; }
        public virtual CourtOfficeTypeGetDto CourtOfficeTypeGetDto { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public virtual City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
