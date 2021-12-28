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
    public partial class UnitEdit : ContentPage
    {
        public UnitEdit()
        {
            InitializeComponent();
        }

        public string str = "";

        private void dolamy_Clicked(object sender, EventArgs e)
        {
            str = "USD";
            Navigation.PopAsync();
        }

        private void cny_Clicked(object sender, EventArgs e)
        {
            str = "CNY";
            Navigation.PopAsync();
        }

        private void eur_Clicked(object sender, EventArgs e)
        {
            str = "EUR";
            Navigation.PopAsync();
        }

        private void gbp_Clicked(object sender, EventArgs e)
        {
            str = "GBP";
            Navigation.PopAsync();
        }

        private void aud_Clicked(object sender, EventArgs e)
        {
            str = "AUD";
            Navigation.PopAsync();
        }

        private void vnd_Clicked(object sender, EventArgs e)
        {
            str = "VND";
            Navigation.PopAsync();
        }

        private void sgd_Clicked(object sender, EventArgs e)
        {
            str = "SGD";
            Navigation.PopAsync();
        }

        private void jpy_Clicked(object sender, EventArgs e)
        {
            str = "JPY";
            Navigation.PopAsync();
        }

        private void krw_Clicked(object sender, EventArgs e)
        {
            str = "KRW";
            Navigation.PopAsync();
        }

        private void hkd_Clicked(object sender, EventArgs e)
        {
            str = "HKD";
            Navigation.PopAsync();
        }

        private void MOP_Clicked(object sender, EventArgs e)
        {
            str = "MOP";
            Navigation.PopAsync();
        }

        private void twd_Clicked(object sender, EventArgs e)
        {
            str = "TWD";
            Navigation.PopAsync();
        }

        private void azn_Clicked(object sender, EventArgs e)
        {
            str = "AZN";
            Navigation.PopAsync();
        }

        private void ars_Clicked(object sender, EventArgs e)
        {
            str = "ARS";
            Navigation.PopAsync();
        }

        private void bob_Clicked(object sender, EventArgs e)
        {
            str = "BOB";
            Navigation.PopAsync();
        }

        private void canada_Clicked(object sender, EventArgs e)
        {
            str = "CAD";
            Navigation.PopAsync();
        }

        private void sek_Clicked(object sender, EventArgs e)
        {
            str = "SEK";
            Navigation.PopAsync();
        }

        private void tzs_Clicked(object sender, EventArgs e)
        {
            str = "TZS";
            Navigation.PopAsync();
        }

        private void uyu_Clicked(object sender, EventArgs e)
        {
            str = "UYU";
            Navigation.PopAsync();
        }
    }
}