using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Globalization;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void language_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void chude_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void hoadondinhky_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void dichvucaocap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void tiente_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyCurrency());
        }

        private void theloai_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void cacthanhvien_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void caidatngansach_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void quanlysocai_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void quanlytaikhoan_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.WalletPage());
        }

        private void timkiemhoadon_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void saoluu_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private async void binhluan_Tapped(object sender, EventArgs e)
        {
            string url = string.Empty;
            var location = RegionInfo.CurrentRegion.Name.ToLower(); 
            if(Device.RuntimePlatform == Device.Android)
            {
                url = "https://play.google.com/store/apps/details?id=com.zotiger.accountbook&hl=vi&gl=US";
            }
            await Browser.OpenAsync(url, BrowserLaunchMode.External);
        }

        private void phanhoi_Tapped(object sender, EventArgs e)
        {
            var address = "namsaoquan@gmail.com";
            Launcher.OpenAsync(new Uri($"mailto:{address}"));
        }

        private void trongkhoang_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void excel_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void them_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        async void banbe_Tapped(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Subject="Clone Money Plus",
                Text="Dang Ngo Hong Hai - Dang Hoang Phong - Nguyen Huy Khoa",
                Title="Do an cuoi ky"
            });
        }
    }
}