using Core.Entities;
using Entities.DTOs.CaseeDtos;
using Entities.DTOs.CaseStatusDtos;
using Entities.DTOs.CaseTypeDtos;
using Entities.DTOs.CourtOfficeDtos;
using Entities.DTOs.CourtOfficeTypeDtos;
using Entities.DTOs.CustomerDtos;
using Entities.DTOs.UserDtos;
using System;

namespace Entities.DTOs.CaseUpdateHistoryDtos
{
    public class CaseUpdateHistoryGetDto : IDto
    {
        public int CasesUpdateHistoryId { get; set; }
        public DateTime ChangeDate { get; set; }
        public GetAllUserListForIgnoreUserList ByWhichUser { get; set; }
        public CaseeGetDto Casee { get; set; }
        public CourtOfficeTypeGetDto CourtOfficeType { get; set; }
        public CourtOfficeGetDto CourtOffice { get; set; }
        public CustomerGetDto Customer { get; set; }
        public CaseTypeGetDto CaseType { get; set; }
        public CaseStatusGetDto CaseStatus { get; set; }
        public int RoleTypeId { get; set; }
        public string CaseNo { get; set; }
        public string Info { get; set; }
        public bool IsEnd { get; set; }
        public bool HasItBeenDecide { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool DoesCourtOfficeTypeChange { get; set; }
        public bool DoesCourtOfficeChange { get; set; }
        public bool DoesCustomerChange { get; set; }
        public bool DoesRoleTypeChange { get; set; }
        public bool DoesCaseTypeChange { get; set; }
        public bool DoesCaseStatusChange { get; set; }
        public bool DoesCaseNoChange { get; set; }
        public bool DoesInfoChange { get; set; }
        public bool DoesItEndChange { get; set; }
        public bool DoesItHasBeenDecideChange { get; set; }
        public bool DoesItStartDateChange { get; set; }
        public bool DoesItDecisionDateChange { get; set; }
        public bool DoesItEndDateChange { get; set; }
    }
}
