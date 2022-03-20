using Core.Entities;

namespace Entities.Concrete
{
    public class ProcessType : IEntity
    {
        public int ProcessTypeId { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
