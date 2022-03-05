using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CaseType : IEntity
    {
        public int CaseTypeId { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public virtual CourtOfficeType CourtOfficeType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Casee> Casees { get; set; }

    }
}
