using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.CaseType
{
    public class CaseTypeUpdateDto : IDto
    {
        public int CaseTypeId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
