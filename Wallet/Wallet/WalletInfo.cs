using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Wallet
{
    public class WalletInfo
    {
        [PrimaryKey,AutoIncrement]

        public int Id { get; set; }
        public string walletName { get; set; }
        public string walletImg { get; set; }

        public string walletPrice { get; set; }

        public string walletCurrency { get; set; }
    }
}
