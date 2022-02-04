using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class TransactionActivityType : IEntity
    {
        [Key]
        public int TransactionActivityTypeId { get; set; }
        public string TransactionActivityTypeNameTr { get; set; }
        public string TransactionActivityTypeNameEn { get; set; }
    }
}
