using System;
using System.Collections.Generic;
using System.Text;


namespace Wallet
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentImg { get; set; }
        public DateTime PaymentTime { get; set; }
        public string PaymentMoney { get; set; }
        public string PaymentTitle { get; set; }
        public string PaymentWallet { get; set; }
        public string PaymentNote { get; set; }

    }
}
