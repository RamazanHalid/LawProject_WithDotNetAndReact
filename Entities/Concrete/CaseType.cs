using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class CaseType : IEntity
    {
        public int CaseTypeId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public CourtOfficeType CourtOfficeType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
