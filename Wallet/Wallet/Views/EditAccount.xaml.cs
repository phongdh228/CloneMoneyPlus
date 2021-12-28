using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAccount : ContentPage
    {
        WalletInfo wallet;
        public string icon { get; set; }
        public string unit { get; set; }

        addEditIcon addPage = new addEditIcon();
        Unit unitPage = new Unit();
        public EditAccount()
        {
            InitializeComponent();
        }
        public EditAccount(WalletInfo wallet)
        {
            InitializeComponent();
            EditInitializing(wallet);  
        }

        private void pickIcon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(addPage);
        }

        private void pickUnit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(unitPage);
        }

        protected override void OnAppearing()
        {
            icon = addPage.str;
            pickIcon.ImageSource = icon;

            unit = unitPage.str;
            pickUnit.Text = unit;
        }

        //public EditAccount(string str)
        //{
        //    InitializeComponent();
        //    icon = str;
        //    this.BindingContext = this;
        //}

        async void EditInitializing(WalletInfo wallet)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWalletTheoId?Id=" + wallet.Id);
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);
            List<WalletInfo> walletOthers = dswallet;
            walletName.Text = walletOthers.ElementAt(0).walletName;
            walletPrice.Text = walletOthers.ElementAt(0).walletPrice.ToString();
            pickUnit.Text = walletOthers.ElementAt(0).walletCurrency;
            edtNote.Text = walletOthers.ElementAt(0).walletNote;
            pickIcon.ImageSource = walletOthers.ElementAt(0).walletImg;
            this.wallet = wallet;
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.DeleteAsync("http://webapimoneyplus.somee.com/api/XuLyController/DeleteWallet?Id=" + wallet.Id);
          
            if (chuoi != null)
            {
                DisplayAlert("Thông Báo", "Xóa ví Thành Công", "OK");
                Navigation.PushAsync(new ManageAccount());
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa ví Thất bại", "OK");
            }
        }

        private async void completeButton_Clicked(object sender, EventArgs e)
        {
            var walletNameValue = walletName.Text;
            var walletPriceValue = walletPrice.Text;
            var walletCurrencyValue = unit;
            var walletImageValue = icon;
            var walletNoteValue = edtNote.Text;

            wallet.walletName = walletNameValue;
            wallet.walletPrice = Int32.Parse(walletPriceValue);
            wallet.walletCurrency = walletCurrencyValue;
            wallet.walletImg = walletImageValue;
            wallet.walletNote = walletNoteValue;

            HttpClient http = new HttpClient();
            var chuoi = await http.PutAsync("http://webapimoneyplus.somee.com/api/XuLyController/ChinhSuaWallet?Id=" + wallet.Id + "&walletName=" + wallet.walletName + "&walletImg=" + wallet.walletImg + "&walletPrice=" + wallet.walletPrice + "&walletCurrency=" + wallet.walletCurrency + "&walletNote=" + wallet.walletNote, null);
          
            if (chuoi != null)
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