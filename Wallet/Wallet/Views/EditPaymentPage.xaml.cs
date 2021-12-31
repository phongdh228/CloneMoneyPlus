using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
    public partial class EditPaymentPage : ContentPage
    {
        Payment payment;
        public EditPaymentPage()
        {
            InitializeComponent();
          
        }

        public EditPaymentPage(Payment payment)
        {
            InitializeComponent();
            MessagingCenter.Subscribe<App>((App)Application.Current, "OnCategoryCreated", (sender) => {
                EditInitializing(payment);
            });
            EditInitializing(payment);
        }

        async void EditInitializing(Payment payment)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPaymentById?PaymentId=" + payment.PaymentId);
            var dspayment = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            List<Payment> paymentOthers = dspayment;
            resultText.Text = paymentOthers.ElementAt(0).PaymentMoney.ToString();
            paymentNote.Text = paymentOthers.ElementAt(0).PaymentNote;
            
            this.payment = payment;
        }

        double money = 0;
        string title = "Tiền công", img = "sachbotui_income_03.png", walletKind = "Sổ cái mặc định";
        DateTime date = DateTime.Today;



        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        private void confirm_Clicked(object sender, EventArgs e)
        {
            onCalculate_Clicked(sender, e);
            var PaymentImgValue = img;
            var PaymentMoneyValue = money.ToString();
            var PaymentTitleValue = title;
            var PaymentNoteValue = paymentNote.Text;
            var PaymentTimeValue = date;
            var PaymentWalletValue = walletKind;

            payment.PaymentImg = PaymentImgValue;
            payment.PaymentMoney = PaymentMoneyValue;
            payment.PaymentTitle = PaymentTitleValue;
            payment.PaymentNote = PaymentNoteValue;
            payment.PaymentTime = PaymentTimeValue;
            payment.PaymentWallet = PaymentWalletValue;

            HttpClient http = new HttpClient();
            var chuoi = http.PutAsync("http://webapimoneyplus.somee.com/api/XuLyController/UpdatePayment?PaymentId=" + payment.PaymentId + "&PaymentImg=" + payment.PaymentImg + "&PaymentTime=" + payment.PaymentTime + "&PaymentMoney=" + payment.PaymentMoney + "&PaymentTitle=" + payment.PaymentTitle + "&PaymentWallet=" + payment.PaymentWallet + "&PaymentNote=" + payment.PaymentNote, null);
            if (chuoi != null)
            {
                Navigation.PushAsync(new Views.Pocketbook());
            }
            else
            {
                DisplayAlert("Thông báo", "Thêm chi tiêu không thành công.", null, "OK");
                Navigation.PopAsync();
            }
        }

        private void pickAccount_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickWalletAccount());
        }

        private void pickMember_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new pickMember());
        }

        private void pickDate_Clicked(object sender, EventArgs e)
        {

        }
        private void onSelectNumber_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "0";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
                money = number;
            }
        }

        private void onSelectOperator_Clicked(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        private void onCalculate_Clicked(object sender, EventArgs e)
        {

            if (currentState == 2)
            {
                var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                money = result;
                currentState = -1;
            }
        }

        private void pickcalculationPoint_Clicked(object sender, EventArgs e)
        {

        }


        private void pickDelete_Clicked(object sender, EventArgs e)
        {

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

        private void tranfer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewTranferPage());
        }


        private void income_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewIncome());
        }
    }
}