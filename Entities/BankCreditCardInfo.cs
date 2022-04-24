using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BankCreditCardInfo
    {
        public string FullName { get; set; }
        public int CreditCardId { get; set; }
        public string CreditCardNo { get; set; }
        public int LatestMonth { get; set; }
        public int LatestYear { get; set; }
        public int SecurityCode { get; set; }
        public float TotalBalance { get; set; }
    }
}
