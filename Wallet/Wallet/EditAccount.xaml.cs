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
    public partial class EditAccount : ContentPage
    {
        WalletInfo wallet;
        public EditAccount()
        {
            InitializeComponent();
           
        }
        public EditAccount(WalletInfo wallet)
        {
            InitializeComponent();
            EditInitializing(wallet);
            
        }

        void EditInitializing(WalletInfo wallet)
        {
            walletName.Text = wallet.walletName;
            walletPrice.Text = wallet.walletPrice;
            walletCurrency.Text = wallet.walletCurrency;
            walletImage.Text = wallet.walletImg;
            this.wallet = wallet;
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            if (db.DeleteOneWallet(wallet))
            {
                DisplayAlert("Thông Báo", "Xóa ví Thành Công", "OK");
                Navigation.PushAsync(new ManageAccount());
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa ví Thất bại", "OK");
            }
        }

        private void completeButton_Clicked(object sender, EventArgs e)
        {
            var walletNameValue = walletName.Text;
            var walletPriceValue = walletPrice.Text;
            var walletCurrencyValue = walletCurrency.Text;
            var walletImageValue = walletImage.Text;
            Database db = new Database();

            wallet.walletName = walletNameValue;
            wallet.walletPrice = walletPriceValue;
            wallet.walletCurrency = walletCurrencyValue;
            wallet.walletImg = walletImageValue;

            if (db.UpdateOneWallet(wallet))
            {
                DisplayAlert("Thông Báo", "Cập nhật ví Thành Công", "OK");
                Navigation.PushAsync(new ManageAccount());
            }
            else
            {
                DisplayAlert("Thông Báo", "Cập nhật ví Thất bại", "OK");
            }
        }
    }
}