using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PaymentDetail
    {
        public string FullName { get; set; }
        public string CreditCardNo { get; set; }
        public int LatestMonth { get; set; }
        public int LatestYear { get; set; }
        public int SecurityCode { get; set; }
        public float HowMuchBalanceLoaded { get; set; }
    }
}
