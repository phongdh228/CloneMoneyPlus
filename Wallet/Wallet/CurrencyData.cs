using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet
{
    public class CurrencyData
    {
        public static IList<Currency> Currencies { get; private set; }

        static CurrencyData()
        {
            Currencies = new List<Currency>();
            Currencies.Add(new Currency
            {
                currencyImg="vietnam.png",
                currencyDetail = "Đồng Việt Nam(VND)",
                currencyName="Đô la Mỹ(USD)"
            });
            Currencies.Add(new Currency
            {
                currencyImg = "usa.png",
                currencyDetail = "Đô la Mỹ(USD)",
                currencyName = "Đồng Việt Nam(VND)"
            });
        }
    }
}
