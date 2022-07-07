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
    public class CaseeGetForDropDownDto : IDto
    {
        public int CaseeId { get; set; }
 
        public string CaseNo { get; set; }
    
    }
}
