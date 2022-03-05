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
        public virtual Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public virtual CourtOfficeType CourtOfficeType { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public string CityId { get; set; }
        public virtual City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Casee> Casees { get; set; }

    }
}
