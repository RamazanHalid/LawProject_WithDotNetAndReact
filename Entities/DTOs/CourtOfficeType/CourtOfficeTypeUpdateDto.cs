using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.CourtOfficeType
{
    public class CourtOfficeTypeUpdateDto: IDto
    {
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeTypeName { get; set; }
     }
}
