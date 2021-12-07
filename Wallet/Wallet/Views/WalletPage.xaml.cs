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
        int total = 0;
        List<WalletInfo> wallets;
        public WalletPage()
        {
            InitializeComponent();
            WalletInit();
            TotalInit();
            totalPrice.Text = "$" + total.ToString();
            totalPrice2.Text = "$" + total.ToString();
        }

        void WalletInit()
        {
            Database db = new Database();
            wallets = db.GetWallets();
            lstWallet.ItemsSource = wallets;
        }


        void TotalInit()
        {
            List<WalletInfo> walletMain = new List<WalletInfo>();
            Database db = new Database();
            List<WalletInfo> walletOthers = db.GetWallets();

            foreach (WalletInfo wallet in walletOthers)
            {
                var walletId  = wallet.Id;
                List<WalletInfo> temp = db.GetOneWallet(walletId);
                if (temp.Count > 0)
                {
                    walletMain.Add(temp.ElementAt(0));
                    total += temp.ElementAt(0).walletPrice;
                }

            };
            lstWallet.ItemsSource = walletMain;
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