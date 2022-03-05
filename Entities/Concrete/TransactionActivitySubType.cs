using Core.Entities; 
using System.ComponentModel.DataAnnotations;
 
namespace Entities.Concrete
{
    public class TransactionActivitySubType : IEntity
    {
        [Key]
        public int TransactionAcitivitySubTypeId { get; set; }
        public int TransactionAcitivityTypeId { get; set; }
        public TransactionActivityType TransactionActivityType { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public string TransactionAcitivitySubTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
