using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CasesUpdateHistory : IEntity
    {
        public int CasesUpdateHistoryId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int ByWhichUserId { get; set; }
        public User ByWhichUser { get; set; }
        public int CaseeId { get; set; }
        public Casee Casee { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public CourtOfficeType CourtOfficeType { get; set; }
        public int CourtOfficeId { get; set; }
        public CourtOffice CourtOffice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CaseTypeId { get; set; }
        public CaseType CaseType { get; set; }
        public int CaseStatusId { get; set; }
        public CaseStatus CaseStatus { get; set; }
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public string CaseNo { get; set; }
        public string Info { get; set; }
        public bool IsEnd { get; set; }
        public bool HasItBeenDecide { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool DoesCourtOfficeTypeChange { get; set; } = false;
        public bool DoesCourtOfficeChange { get; set; } = false;
        public bool DoesCustomerChange { get; set; } = false;
        public bool DoesRoleTypeChange { get; set; } = false;
        public bool DoesCaseTypeChange { get; set; } = false;
        public bool DoesCaseStatusChange { get; set; } = false;
        public bool DoesCaseNoChange { get; set; } = false;
        public bool DoesInfoChange { get; set; } = false;
        public bool DoesItEndChange { get; set; } = false;
        public bool DoesItHasBeenDecideChange { get; set; } = false;
        public bool DoesItStartDateChange { get; set; } = false;
        public bool DoesItDecisionDateChange { get; set; } = false;
        public bool DoesItEndDateChange { get; set; } = false;
    }
}
