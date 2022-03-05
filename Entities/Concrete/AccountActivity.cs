using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AccountActivity : IEntity
    {
        public int AccountActivityId { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int OrderTypeId { get; set; }
        public OrderType OrderType { get; set; }
        public int AccountActivityTypeId { get; set; }
        public AccountActivityType AccountActivityType { get; set; }
        public int AccountActivityStatusId { get; set; }
        public AccountActivityStatus AccountActivityStatus { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public DateTime Expiry { get; set; }
        public float TaxCost { get; set; }
        public float Coast { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
        public int OrderCount { get; set; }
    }
}
