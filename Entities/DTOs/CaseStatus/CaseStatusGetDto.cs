using Core.Entities;
using Entities.Concrete;
using Entities.DTOs.CourtOfficeType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CaseStatusGetDto : IDto
    {
        public int CaseStatusId { get; set; }
        public CourtOfficeTypeGetDto CourtOfficeTypeGetDto { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
