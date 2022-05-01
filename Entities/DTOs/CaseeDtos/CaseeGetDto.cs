using Core.Entities;
using Entities.Concrete;
using Entities.DTOs.CaseIngonereUserDtos;
using Entities.DTOs.CaseStatusDtos;
using Entities.DTOs.CaseTypeDtos;
using Entities.DTOs.CourtOfficeDtos;
using Entities.DTOs.CourtOfficeTypeDtos;
using Entities.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;

namespace Entities.DTOs.CaseeDtos
{
    public class CaseeGetDto : IDto
    {
        public int CaseeId { get; set; }
        public CourtOfficeTypeGetDto CourtOfficeType { get; set; }
        public CourtOfficeGetDto CourtOffice { get; set; }
        public CustomerGetDto Customer { get; set; }
        public CaseTypeGetDto CaseType { get; set; }
        public CaseStatusGetDto CaseStatus { get; set; }
        public List<CaseIgnoreGetDto> CaseIgnoreUsers { get; set; }
        public int RoleTypeId { get; set; }
        public string CaseNo { get; set; }
        public string Info { get; set; }
        public bool IsEnd { get; set; }
        public bool HasItBeenDecide { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
