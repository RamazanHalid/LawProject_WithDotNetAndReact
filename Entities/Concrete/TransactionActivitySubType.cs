using Core.Entities;
using System.Collections;
using System.Collections.Generic;
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
        public virtual Licence Licence { get; set; }
        public string TransactionActivitySubTypeName { get; set; }
        public bool IsActive { get; set; }
        //public virtual ICollection<TransactionActivity> TransactionActivities { get; set; }

    }
}
