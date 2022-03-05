using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.ProcessType
{
    public class ProcessTypeGetDto : IDto
    {
        public int ProcessTypeId { get; set; }
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
