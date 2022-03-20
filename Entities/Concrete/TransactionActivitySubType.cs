using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TransactionActivitySubType : IEntity
    {
        [Key]
        public int TransactionActivitySubTypeId { get; set; }
        public int TransactionActivityTypeId { get; set; }
        public TransactionActivityType TransactionActivityType { get; set; }
        public int LicenceId { get; set; }
        public  Licence Licence { get; set; }
        public string TransactionActivitySubTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
