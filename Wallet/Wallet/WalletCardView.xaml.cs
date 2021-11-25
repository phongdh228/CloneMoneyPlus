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
    public partial class WalletCardView : ContentPage
    {
        List<WalletInfo> wallets;
        public WalletCardView()
        {
            InitializeComponent();
            
        }

        public WalletCardView(WalletInfo wallet)
        {
            InitializeComponent();
            CardViewInit(wallet);
        }

        void CardViewInit(WalletInfo wallet)
        {
            Database db = new Database();
            wallets = db.GetOneWallet(wallet.Id);
            lstWallet.ItemsSource = wallets;
        }

        private void lstWallet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WalletInfo selectedWallet = e.SelectedItem as WalletInfo;
            Navigation.PushAsync(new EditAccount(selectedWallet));
        }
    }
}