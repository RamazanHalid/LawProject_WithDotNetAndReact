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
        public virtual Licence Licence { get; set; }
        public string TaskTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
