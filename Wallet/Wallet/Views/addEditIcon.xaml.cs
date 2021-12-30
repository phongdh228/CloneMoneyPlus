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
    public partial class addEditIcon : ContentPage
    {
        public string str= "";
        public addEditIcon()
        {
            InitializeComponent();
        }

        public addEditIcon(EditAccount editAccount)
        {
            InitializeComponent();
        }


        string img = "icon_atm.jpg";

        private void tiengiay_Clicked(object sender, EventArgs e)
        {
            str = "icon_03.png";
            Navigation.PopAsync();
        }


        private void atm_Clicked(object sender, EventArgs e)
        {
            str = "icon_05.png";
            Navigation.PopAsync();
        }

        private void bit_Clicked(object sender, EventArgs e)
        {
            str = "icon_07.png";
            Navigation.PopAsync();
        }

        private void tusach_Clicked(object sender, EventArgs e)
        {
            str = "icon_09.png";
            Navigation.PopAsync();
        }

        private void hungtien_Clicked(object sender, EventArgs e)
        {
            str = "icon_15.png";
            Navigation.PopAsync();
        }

        private void bangtien_Clicked(object sender, EventArgs e)
        {
            str = "icon_16.png";
            Navigation.PopAsync();
        }

        private void dongtien_Clicked(object sender, EventArgs e)
        {
            str = "icon_17.png";
            Navigation.PopAsync();
        }

        private void mastercard_Clicked(object sender, EventArgs e)
        {
            str = "icon_18.png";
            Navigation.PopAsync();
        }

        private void visa_Clicked(object sender, EventArgs e)
        {
            str = "icon_23.png";
            Navigation.PopAsync();
        }

        private void amex_Clicked(object sender, EventArgs e)
        {
            str = "icon_24.png";
            Navigation.PopAsync();
        }

        private void w_Clicked(object sender, EventArgs e)
        {
            str = "icon_25.png";
            Navigation.PopAsync();
        }

        private void heodat_Clicked(object sender, EventArgs e)
        {
            str = "icon_26.png";
            Navigation.PopAsync();
        }

        private void paypal_Clicked(object sender, EventArgs e)
        {
            str = "icon_31.png";
            Navigation.PopAsync();
        }

        private void jcb_Clicked(object sender, EventArgs e)
        {
            str = "icon_32.png";
            Navigation.PopAsync();
        }

        private void wechat_Clicked(object sender, EventArgs e)
        {
            str = "icon_33.png";
            Navigation.PopAsync();
        }

        private void applepay_Clicked(object sender, EventArgs e)
        {
            str = "icon_34.png";
            Navigation.PopAsync();
        }

        private void mayatm_Clicked(object sender, EventArgs e)
        {
            str = "icon_39.png";
            Navigation.PopAsync();
        }

        private void coin_Clicked(object sender, EventArgs e)
        {
            str = "icon_40.png";
            Navigation.PopAsync();
        }

        private void city_Clicked(object sender, EventArgs e)
        {
            str = "icon_41.png";
            Navigation.PopAsync();
        }

        private void discover_Clicked(object sender, EventArgs e)
        {
            str = "icon_42.png";
            Navigation.PopAsync();
        }

        private void gpay_Clicked(object sender, EventArgs e)
        {
            str = "icon_47.png";
            Navigation.PopAsync();
        }

        private void hsbc_Clicked(object sender, EventArgs e)
        {
            str = "icon_48.png";
            Navigation.PopAsync();
        }

        private void atm2_Clicked(object sender, EventArgs e)
        {
            str = "icon_49.png";
            Navigation.PopAsync();
        }

        private void stripe_Clicked(object sender, EventArgs e)
        {
            str = "icon_50.png";
            Navigation.PopAsync();
        }

        private void atm3_Clicked(object sender, EventArgs e)
        {
            str = "icon_55.png";
            Navigation.PopAsync();
        }

        private void thumuc_Clicked(object sender, EventArgs e)
        {
            str = "icon_56.png";
            Navigation.PopAsync();
        }

        private void damau_Clicked(object sender, EventArgs e)
        {
            str = "icon_57.png";
            Navigation.PopAsync();
        }

        private void dola_Clicked(object sender, EventArgs e)
        {
            str = "icon_58.png";
            Navigation.PopAsync();
        }

        private void atm4_Clicked(object sender, EventArgs e)
        {
            str = "icon_63.png";
            Navigation.PopAsync();
        }

        private void line_Clicked(object sender, EventArgs e)
        {
            str = "icon_64.png";
            Navigation.PopAsync();
        }


        private void phone_Clicked(object sender, EventArgs e)
        {
            str = "icon_66.png";
            Navigation.PopAsync();
        }

        private void v_Clicked(object sender, EventArgs e)
        {
            str = "icon_65.png";
            Navigation.PopAsync();
        }

    }
}