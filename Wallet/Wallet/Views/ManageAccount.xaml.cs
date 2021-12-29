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
    public partial class ManageAccount : ContentPage
    {
        List<WalletInfo> wallets;
        public ManageAccount()
        {
            InitializeComponent();
            AccountInit();
        }

        void AccountInit()
        {
            Database db = new Database();
            wallets = db.GetWallets();
            lstWallet.ItemsSource = wallets;
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewAccount());
        }

        private void lstWallet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WalletInfo selectedWallet = e.SelectedItem as WalletInfo;
            Navigation.PushAsync(new EditAccount(selectedWallet));
        }

        private void completeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.WalletPage());
        }
    }
}