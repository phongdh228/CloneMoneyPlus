using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            ListPocket(wallet);
           
        }


        async void CardViewInit(WalletInfo wallet)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWalletTheoId?Id=" + wallet.Id);
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);
            lstWallet.ItemsSource = dswallet;
        }

        async void ListPocket(WalletInfo wallet)
        {
            try
            {
                HttpClient http = new HttpClient();
                var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPaymentByWalletId?walletId=" + wallet.Id);
                var dswallet = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
                lstPocket.ItemsSource = dswallet;

            }
            catch
            {

            }

        }

        private void lstWallet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WalletInfo selectedWallet = e.SelectedItem as WalletInfo;
            Navigation.PushAsync(new EditAccount(selectedWallet));
        }
    }
}