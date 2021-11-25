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
    public partial class AddNewWalletPage : ContentPage
    {
        public AddNewWalletPage()
        {
            InitializeComponent();
            BindingContext = new MyWalletPageViewModel();
        }
        public AddNewWalletPage(Account account)
        {
            InitializeComponent();
            Title = "Tạo nên "+ account.accountName;
        }

        private void completeButton_Clicked(object sender, EventArgs e)
        {
            WalletInfo newWallet = new WalletInfo();
            newWallet.walletName = walletName.Text;
            newWallet.walletImg = walletImage.Text;
            newWallet.walletPrice = walletPrice.Text;
            newWallet.walletCurrency = walletCurrency.Text;


            Database db = new Database();
            if (db.AddNewWallet(newWallet))
            {
                DisplayAlert("Thông báo", "Thêm ví thành công", null, "OK");
                Navigation.PushAsync(new ManageAccount());
            }
            else
            {
                DisplayAlert("Thông báo", "Thêm ví thất bại", null, "OK");
            }
        }
    }
}