using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickWalletAccount : ContentPage
    {
        public bool change_wallet = false;
        public PickWalletAccount()
        {
            InitializeComponent();
            HienThiWallet();
        }
        async void HienThiWallet()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWallet");
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);
            lstWallet.ItemsSource = dswallet;
        }
        public WalletInfo walletPublic;
        private void lstWallet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WalletInfo selectedWallet = e.SelectedItem as WalletInfo;
            walletPublic = selectedWallet;
            change_wallet = true;
            Navigation.PopAsync();
        }

        private void editButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageAccount());
        }
    }
}