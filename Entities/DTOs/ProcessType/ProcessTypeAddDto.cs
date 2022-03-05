using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.ProcessType
{
    public class ProcessTypeAddDto: IDto
    { 
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
