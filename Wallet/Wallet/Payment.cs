using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Wallet
{
    public class Payment
    {
        [PrimaryKey, AutoIncrement]
        public string PaymentImg { get; set; }
        public string PaymentTime { get; set; }
        public string PaymentMoney { get; set; }
        public string PaymentTitle { get; set; }
        public string PaymentWallet { get; set; }
        public string PaymentNote { get; set; }

    }
}
