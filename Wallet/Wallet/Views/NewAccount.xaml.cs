using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAccount : ContentPage
    {
        public NewAccount()
        {
            InitializeComponent();
            AccountInitializing();
        }

        void AccountInitializing()
        {
            List<Account> listAccount = new List<Account>();
            listAccount.Add(new Account { accountImg = "money.jpg", accountName = "Tiền mặt" });
            listAccount.Add(new Account { accountImg = "atm.jpg", accountName = "Thẻ tiền gửi" });
            listAccount.Add(new Account { accountImg = "atm.jpg", accountName = "Thẻ tín dụng" });
            listAccount.Add(new Account { accountImg = "imagine.jpg", accountName = "Tài khoản ảo", accountDescription="Paypal, tiền tệ kỹ thuật số và thẻ nạp tiền" });
            listAccount.Add(new Account { accountImg = "invest.jpg", accountName = "Đầu tư", accountDescription = "Đầu tư vào tài khoản chính" });
            listAccount.Add(new Account { accountImg = "income.jpg", accountName = "Phải thu", accountDescription = "Tiền chưa được nhận" });
            listAccount.Add(new Account { accountImg = "pay.jpg", accountName = "Phải trả", accountDescription = "Tiền nào nên được trả" });

            lstAccount.ItemsSource = listAccount;
        }

        private void lstAccount_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lstAccount.SelectedItem != null)
            {
                Account selectedAccount = (Account)lstAccount.SelectedItem;
                Navigation.PushAsync(new AddNewWalletPage(selectedAccount));
            }
        }
    }
}