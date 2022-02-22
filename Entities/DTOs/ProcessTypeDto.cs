using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProcessTypeDto : IDto
    {
        public int ProcessTypeId { get; set; }
        public string ProcessTypeNameTr { get; set; }
        public string ProcessTypeNameEn { get; set; }
        public bool IsActive { get; set; }
    }
}
