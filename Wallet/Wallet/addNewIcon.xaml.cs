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
    public partial class addNewIcon : ContentPage
    {
        public addNewIcon()
        {
            InitializeComponent();
        }

        string img = "icon_atm.jpg";
       

        private void tiengiay_Clicked(object sender, EventArgs e)
        {
            img = "icon_tiengiay.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void atm_Clicked(object sender, EventArgs e)
        {
            img = "icon_atm.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void bit_Clicked(object sender, EventArgs e)
        {
            img = "icon_bit.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void tusach_Clicked(object sender, EventArgs e)
        {
            img = "icon_tusach.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void hungtien_Clicked(object sender, EventArgs e)
        {
            img = "icon_hungtien.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void bangtien_Clicked(object sender, EventArgs e)
        {
            img = "icon_bangtien.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void dongtien_Clicked(object sender, EventArgs e)
        {
            img = "icon_dongtien.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void mastercard_Clicked(object sender, EventArgs e)
        {
            img = "icon_mastercard.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void visa_Clicked(object sender, EventArgs e)
        {
            img = "icon_visa.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void amex_Clicked(object sender, EventArgs e)
        {
            img = "icon_amex.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void w_Clicked(object sender, EventArgs e)
        {
            img = "icon_w.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void heodat_Clicked(object sender, EventArgs e)
        {
            img = "icon_heodat.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void paypal_Clicked(object sender, EventArgs e)
        {
            img = "icon_paypal.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void jcb_Clicked(object sender, EventArgs e)
        {
            img = "icon_jcb.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void wechat_Clicked(object sender, EventArgs e)
        {
            img = "icon_wechat.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void applepay_Clicked(object sender, EventArgs e)
        {
            img = "icon_applepay.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void mayatm_Clicked(object sender, EventArgs e)
        {
            img = "icon_mayatm.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void coin_Clicked(object sender, EventArgs e)
        {
            img = "icon_coin.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void city_Clicked(object sender, EventArgs e)
        {
            img = "icon_city.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void discover_Clicked(object sender, EventArgs e)
        {
            img = "icon_discover.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void gpay_Clicked(object sender, EventArgs e)
        {
            img = "icon_gpay.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void hsbc_Clicked(object sender, EventArgs e)
        {
            img = "icon_hsbc.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void atm2_Clicked(object sender, EventArgs e)
        {
            img = "icon_atm2.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void stripe_Clicked(object sender, EventArgs e)
        {
            img = "icon_stripe.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void atm3_Clicked(object sender, EventArgs e)
        {
            img = "icon_atm3.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void thumuc_Clicked(object sender, EventArgs e)
        {
            img = "icon_thumuc.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void damau_Clicked(object sender, EventArgs e)
        {
            img = "icon_damau.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void dola_Clicked(object sender, EventArgs e)
        {
            img = "icon_dola.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void atm4_Clicked(object sender, EventArgs e)
        {
            img = "icon_atm4.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void line_Clicked(object sender, EventArgs e)
        {
            img = "icon_line.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }


        private void phone_Clicked(object sender, EventArgs e)
        {
            img = "icon_phone.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

        private void v_Clicked(object sender, EventArgs e)
        {
            img = "icon_v.jpg";
            Navigation.PushAsync(new AddNewWalletPage(img));
        }

       
    }
}