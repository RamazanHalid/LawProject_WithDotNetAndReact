using Core.Entities;
using System;

namespace Entities.DTOs.CaseeDtos
{
    public class CaseeUpdateDto : IDto
    {
        public int CaseeId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public int CourtOfficeId { get; set; }
        public int CustomerId { get; set; }
        public int CaseTypeId { get; set; }
        public int CaseStatusId { get; set; }
        public int RoleTypeId { get; set; }
        public string CaseNo { get; set; }
        public string Info { get; set; }
        public bool IsEnd { get; set; }
        public bool HasItBeenDecide { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
