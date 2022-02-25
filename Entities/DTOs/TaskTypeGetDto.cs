using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TaskTypeGetDto
    {
        public int TaskTypeId { get; set; }
         public string TaskTypeNameTr { get; set; }
        public string TaskTypeNameEn { get; set; }
        public bool IsActive { get; set; }
    }
}
