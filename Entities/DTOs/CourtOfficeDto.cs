using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CourtOfficeDto : IDto
    {
        public int CourtOfficeId { get; set; }
        public string CourtOfficeName { get; set; }
        public CourtOfficeType CourtOfficeType { get; set; }
        public string Adderess { get; set; }
        public City City { get; set; }
        public string FirstPhoneNumber { get; set; }
        public string FirstPhoneNumberAdd { get; set; }
        public string SecondPhoneNumber { get; set; }
        public string SecondPhoneNumberAdd { get; set; }
        public string ThirdPhoneNumber { get; set; }
        public string ThirdPhoneNumberAdd { get; set; }
        public string Fax { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }


    }
}
