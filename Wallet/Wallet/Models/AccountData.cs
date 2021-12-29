using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet
{
    public class AccountData
    {
        public static IList<AccountImage> Accounts { get; private set; }

        static AccountData()
        {
            Accounts = new List<AccountImage>();
            Accounts.Add(new AccountImage
            {
               accountImageImg = "amex.png",
               accountImageName = "Amex"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "apple_pay.png",
                accountImageName = "Apple Pay"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "atm.jpg",
                accountImageName = "Thẻ ATM"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "atm2.png",
                accountImageName = "Master Card"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "imagine.jpg",
                accountImageName = "Big Icon"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "coin.jpg",
                accountImageName = "Tiền đồng"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "income.jpg",
                accountImageName = "Tiền vào"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "invest.jpg",
                accountImageName = "Đầu tư"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "money.jpg",
                accountImageName = "Tiền mặt"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "pay.jpg",
                accountImageName = "Tiền túi"
            });
            Accounts.Add(new AccountImage
            {
                accountImageImg = "wallet.png",
                accountImageName = "Ví tiền"
            });
        }
    }
}
