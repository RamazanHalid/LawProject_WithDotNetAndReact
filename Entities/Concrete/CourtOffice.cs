using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class CourtOffice : IEntity
    {
        public int CourtOfficeId { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public  CourtOfficeType CourtOfficeType { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
