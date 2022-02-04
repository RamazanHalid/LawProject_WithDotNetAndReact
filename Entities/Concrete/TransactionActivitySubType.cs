using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class TransactionActivitySubType : IEntity
    {
        [Key]
        public int TransactionAcitivitySubTypeId { get; set; }
        public int TransactionAcitivityTypeId { get; set; }
        public TransactionActivityType TransactionActivityType{ get; set; }
        public int LicenceId { get; set; }
        public string TransactionAcitivitySubTypeNameTr { get; set; }
        public string TransactionAcitivitySubTypeNameEn { get; set; }
        public bool IsActive { get; set; }

    }
}
