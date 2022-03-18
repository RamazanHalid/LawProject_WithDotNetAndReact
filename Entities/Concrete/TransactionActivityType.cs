using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TransactionActivityType : IEntity
    {
        [Key]
        public int TransactionActivityTypeId { get; set; }
        public string TransactionActivityTypeName { get; set; }
        //public virtual ICollection<TransactionActivitySubType> TransactionActivitySubTypes { get; set; }
    }
}
