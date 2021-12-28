using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletPage : ContentPage
    {
        async void HienThiWallet()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWallet");
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);
            lstWallet.ItemsSource = dswallet;
        }
        int total = 0;

        async void TotalInit()
        {
            List<WalletInfo> walletMain = new List<WalletInfo>();
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWallet");
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);
            List<WalletInfo> walletOthers = dswallet;


            foreach (WalletInfo wallet in walletOthers)
            {
                var walletId = wallet.Id;
                var chuoi2 = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWalletTheoId?Id=" + walletId.ToString());
                var dswallet2 = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi2);
                List<WalletInfo> temp = dswallet2;
                if (temp.Count > 0)
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
            totalPrice.Text = "$" + total.ToString();
            totalPrice2.Text = "$" + total.ToString();
        }
        public WalletPage()
        {
            InitializeComponent();
            //WalletInit();
            HienThiWallet();
            TotalInit();
        }

      
        //void WalletInit()
        //{
        //    Database db = new Database();
        //    wallets = db.GetWallets();
        //    lstWallet.ItemsSource = wallets;
        //}
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