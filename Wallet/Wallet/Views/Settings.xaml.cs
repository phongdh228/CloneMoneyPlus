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
            Navigation.PushAsync(new MoneyPlusPremium());
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
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void timkiemhoadon_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void saoluu_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void binhluan_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }

        private void phanhoi_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
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

        private void banbe_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoneyPlusPremium());
        }
    }
}