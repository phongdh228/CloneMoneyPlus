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
    public partial class addNewPaymentPage : ContentPage
    {
        int money=0;
        string title = "Chế độ ăn", img = "";
     
        public addNewPaymentPage()
        {
            InitializeComponent();
        }

        private void pickAccount_Clicked(object sender, EventArgs e)
        {

        }

        private void pickMember_Clicked(object sender, EventArgs e)
        {

        }

        private void pickDate_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber7_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber8_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber9_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationX_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcaculationDivine_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber4_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber5_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber6_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationSubtract_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber1_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber2_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber3_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationAdd_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationPoint_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber0_Clicked(object sender, EventArgs e)
        {

        }

        private void pickDelete_Clicked(object sender, EventArgs e)
        {

        }

        private void confirm_Clicked(object sender, EventArgs e)
        {
            Payment newPayment = new Payment();
            newPayment.PaymentImg = img;
            newPayment.PaymentMoney = money.ToString();
            newPayment.PaymentTitle = title;
            /*
            newPayment.PaymentNote = ;
            newPayment.PaymentTime = ;
            newPayment.PaymentWallet = ;
            */

            Database db = new Database();
            if (db.AddNewPayment(newPayment))
            {
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Thông báo", "Thêm ví thất bại", null, "OK");
            }
        }

        private void tranfer_Clicked(object sender, EventArgs e)
        {

        }

        private void income_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewIncome());
        }

        private void chedoan_Clicked(object sender, EventArgs e)
        {
            title = "Chế độ ăn";
            img = "sachbotui_expend_01.png";
        }

        private void hangngay_Clicked(object sender, EventArgs e)
        {
            title = "Hàng ngày";
            img = "sachbotui_expend_03.png";
        }

        private void giaothong_Clicked(object sender, EventArgs e)
        {
            title = "Giao thông";
            img = "sachbotui_expend_05.png";
        }

        private void xahoi_Clicked(object sender, EventArgs e)
        {
            title = "Xã hội";
            img = "sachbotui_expend_07.png";
        }

        private void dancu_Clicked(object sender, EventArgs e)
        {
            title = "Dân cư";
            img = "sachbotui_expend_12.png";
        }

        private void quatang_Clicked(object sender, EventArgs e)
        {
            title = "Quà tặng";
            img = "sachbotui_expend_13.png";
        }

        private void giaotiep_Clicked(object sender, EventArgs e)
        {
            title = "Giao tiếp";
            img = "sachbotui_expend_14.png";
        }

        private void quanao_Clicked(object sender, EventArgs e)
        {
            title = "Quần áo";
            img = "sachbotui_expend_15.png";
        }

        private void giaitri_Clicked(object sender, EventArgs e)
        {
            title = "Giải trí";
            img = "sachbotui_expend_20.png";
        }

        private void sacdep_Clicked(object sender, EventArgs e)
        {
            title = "Sắc đẹp";
            img = "sachbotui_expend_21.png";
        }

        private void ykhoa_Clicked(object sender, EventArgs e)
        {
            title = "Y khoa";
            img = "sachbotui_expend_22.png";
        }

        private void thue_Clicked(object sender, EventArgs e)
        {
            title = "Thuế";
            img = "sachbotui_expend_23.png";
        }

        private void giaoduc_Clicked(object sender, EventArgs e)
        {
            title = "Giáo dục";
            img = "sachbotui_expend2_03.png";
        }

        private void treem_Clicked(object sender, EventArgs e)
        {
            title = "Trẻ em";
            img = "caidat_thanhvien_14.png";
        }

        private void thunuoi_Clicked(object sender, EventArgs e)
        {
            title = "Thú nuôi";
            img = "sachbotui_expend2_07.png";
        }

        private void dulich_Clicked(object sender, EventArgs e)
        {
            title = "Du lịch";
            img = "sachbotui_expend2_09.png";
        }
    }
}