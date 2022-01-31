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
        public string ProcessTypeNameTr { get; set; }
        public string ProcessTypeNameEn { get; set; }
        public bool IsActive { get; set; }

    }
}
