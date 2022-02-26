﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CaseStatusUpdateDto : IDto
    {
        public int CaseStatusId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }
    }
}