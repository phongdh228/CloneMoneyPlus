using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pickMember : ContentPage
    {
        public string str = "";
        public pickMember()
        {
            InitializeComponent();
        }

        string img = "caidat_thanhvien_03.png";
        private void lstMember_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            str = "caidat_thanhvien_03.png";
            Navigation.PopAsync();
        }

        private void canhan_Clicked(object sender, EventArgs e)
        {
            str = "caidat_thanhvien_03.png";
            Navigation.PopAsync();
        }

        private void vo_Clicked(object sender, EventArgs e)
        {
            str = "caidat_thanhvien_10.png";
            Navigation.PopAsync();
        }

        private void chong_Clicked(object sender, EventArgs e)
        {
            str = "caidat_thanhvien_12.png";
            Navigation.PopAsync();
        }

        private void concai_Clicked(object sender, EventArgs e)
        {
            str = "caidat_thanhvien_14.png";
            Navigation.PopAsync();
        }

        private void chame_Clicked(object sender, EventArgs e)
        {
            str = "caidat_thanhvien_16.png";
            Navigation.PopAsync();
        }

        private void giadinh_Clicked(object sender, EventArgs e)
        {
            str = "caidat_thanhvien_18.png";
            Navigation.PopAsync();
        }
    }
}