﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Casee : IEntity
    {
        public int CaseeId { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public virtual CourtOfficeType CourtOfficeType { get; set; }
        public int CourtOfficeId { get; set; }
        public virtual CourtOffice CourtOffice { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CaseTypeId { get; set; }
        public virtual CaseType CaseType { get; set; }
        public int CaseStatusId { get; set; }
        public virtual CaseStatus CaseStatus { get; set; }
        public int RoleTypeId { get; set; }
        public string CaseNo { get; set; }
        public string Info { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}