using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class TransactionActivitySubTypeDto : IDto
    {
        [Key]
        public int TransactionAcitivitySubTypeId { get; set; }
        public TransactionActivityType TransactionActivityType { get; set; }
        public string TransactionAcitivitySubTypeNameTr { get; set; }
        public string TransactionAcitivitySubTypeNameEn { get; set; }
        public bool IsActive { get; set; }

    }
}
