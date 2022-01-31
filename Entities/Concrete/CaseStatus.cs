using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CaseStatus : IEntity
    {
        public int CaseStatusId { get; set; }
        public int LicenceId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public CourtOfficeType CourtOffice { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }

    }
}
