using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.CaseType
{
    public class CaseTypeGetDto : IDto
    {
        public int CaseTypeId { get; set; }
        public CourtOfficeType CourtOfficeType { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }


    }
}
