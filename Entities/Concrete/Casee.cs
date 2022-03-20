using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Casee : IEntity
    {
        public int CaseeId { get; set; }
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
        public DateTime? StartDate { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
