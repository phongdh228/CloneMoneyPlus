using System;
using System.Collections.Generic;
using System.Text;


namespace Wallet
{
    public class WalletInfo
    {
    
        public int Id { get; set; }
        public string walletName { get; set; }
        public string walletImg { get; set; }

        public int walletPrice { get; set; }

        public string walletCurrency { get; set; }

        public string walletNote { get; set; }

        public int totalAmount { get; set; }
    }

}
