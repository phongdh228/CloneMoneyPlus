using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewWalletPage : ContentPage
    {
        WalletInfo wallet;
        public string icon { get; set; }
        public string unit { get; set; }

        addNewIcon addPage = new addNewIcon();
        Unit unitPage = new Unit();
        public AddNewWalletPage()
        {
            InitializeComponent();
            
        }
        public AddNewWalletPage(string str)
        {
            InitializeComponent();
            icon = str;
            this.BindingContext = this;
        }
        public AddNewWalletPage(Account account)
        {
            InitializeComponent();
            Title = "Tạo nên "+ account.accountName;
        }

        protected override void OnAppearing()
        {
            icon = addPage.str;
            pickIcon.ImageSource = icon;

            unit = unitPage.str;
            pickUnit.Text = unit;
        }


        public void completeButton_Clicked(object sender, EventArgs e)
        {
            WalletInfo newWallet = new WalletInfo();
            newWallet.walletName = walletName.Text;
            newWallet.walletImg = icon;
            newWallet.walletPrice = Int32.Parse(walletPrice.Text);
            newWallet.walletCurrency = unit;
            newWallet.walletNote = edtNote.Text;

            HttpClient http = new HttpClient();
            var chuoi = http.PostAsync("http://webapimoneyplus.somee.com/api/XuLyController/TaoWallet?walletName=" + newWallet.walletName + "&walletImg=" + newWallet.walletImg + "&walletPrice=" + newWallet.walletPrice + "&walletCurrency=" + newWallet.walletCurrency + "&walletNote=" + newWallet.walletNote, null);
            if (chuoi != null)
            {
                Navigation.PushAsync(new ManageAccount());
                DisplayAlert("Thông báo", "Tạo ví thành công", null, "OK");
            }
           
        }

        private void pickIcon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(addPage);
        }

        private void pickUnit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(unitPage);
        }
    }
}