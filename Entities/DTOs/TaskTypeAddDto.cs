using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TaskTypeAddDto : IDto
    {
        public string TaskTypeNameTr { get; set; }
        public string TaskTypeNameEn { get; set; }
        public bool IsActive { get; set; }
    }
}
