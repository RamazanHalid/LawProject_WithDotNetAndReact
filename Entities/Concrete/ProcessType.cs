using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProcessType : IEntity
    {
        public int ProcessTypeId { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
