﻿using Core.Entities;

namespace Entities.Concrete
{
    public class CaseStatus : IEntity
    {
        public int CaseStatusId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public CourtOfficeType CourtOfficeType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
