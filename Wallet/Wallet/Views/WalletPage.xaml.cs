using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletPage : ContentPage
    {
        List<WalletInfo> wallets;
        public WalletPage()
        {
            InitializeComponent();
            WalletInit();
           
        }

        void WalletInit()
        {
            Database db = new Database();
            wallets = db.GetWallets();
            lstWallet.ItemsSource = wallets;
        }



        private void lstWallet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WalletInfo selectedWallet = e.SelectedItem as WalletInfo;
            Navigation.PushAsync(new WalletCardView(selectedWallet));
        }

        private void addNewWallet_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNewWalletPage());
        }

        private void manageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageAccount());
        }

        private void currencyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyCurrency());
        }
    }
}