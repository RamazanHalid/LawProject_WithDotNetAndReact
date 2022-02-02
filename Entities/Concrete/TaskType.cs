using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class TaskType : IEntity
    {
        public int TaskTypeId { get; set; }
        public int LicenceId { get; set; }
        public string TaskTypeNameTr { get; set; }
        public string TaskTypeNameEn { get; set; }
        public bool IsActive { get; set; }

    }
}
