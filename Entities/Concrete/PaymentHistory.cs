using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PaymentHistory : IEntity
    {
        public int Id { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Balance { get; set; }
    }
}
