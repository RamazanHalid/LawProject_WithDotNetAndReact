using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class TaskType : IEntity
    {
        public int TaskTypeId { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }
        public string TaskTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
