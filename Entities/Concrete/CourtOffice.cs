using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CourtOffice : IEntity
    {
        public int CourtOfficeId { get; set; }
        public int LicenceId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public string CityId { get; set; }
        public string FirstPhoneNumber { get; set; }
        public string FirstPhoneNumberAdd { get; set; }
        public string SecondPhoneNumber { get; set; }
        public string SecondPhoneNumberAdd { get; set; }
        public string ThirdPhoneNumber { get; set; }
        public string ThirdPhoneNumberAdd { get; set; }
        public string Fax { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }

    }
}
