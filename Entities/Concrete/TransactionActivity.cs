using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class TransactionActivity : IEntity
    {
        public int TransactionActivityId { get; set; }
        public int TransactionActivitySubTypeId { get; set; }
        public virtual TransactionActivitySubType TransactionActivitySubType { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int UserWhoAddId { get; set; }
        public User UserWhoAdd { get; set; }
        public string Info { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsItExpense { get; set; }
        public bool IsApproved { get; set; }
        public int? WhoApprovedId { get; set; }
        public User WhoApproved { get; set; }
    }
}