using Newtonsoft.Json;
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
    public partial class addNewIncome : ContentPage
    {
        PickWalletAccount walletNew = new PickWalletAccount();
        pickMember memberChosen = new pickMember();

        public string memberIcon { get; set; }
        public string memberTitle { get; set; }
        public addNewIncome()
        {
            InitializeComponent();
        }

        public addNewIncome(WalletInfo wallet)
        {
            InitializeComponent();
            PickAccountInit(wallet);
        }

        public int walletIdNew;
        public string walletImageNew;

        async void PickAccountInit(WalletInfo wallet)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWalletTheoId?Id=" + wallet.Id);
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);

            pickAccount.ImageSource = dswallet.ElementAt(0).walletImg;
            walletImageNew = dswallet.ElementAt(0).walletImg;
            walletKind = dswallet.ElementAt(0).walletName;
            walletIdNew = dswallet.ElementAt(0).Id;
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
            Payment newPayment = new Payment();
            newPayment.PaymentImg = img;
            newPayment.PaymentMoney = "+" + (money).ToString();
            newPayment.PaymentTitle = title;
            newPayment.PaymentNote = paymentNote.Text;
            newPayment.PaymentTime = date;
            newPayment.PaymentWallet = walletKind;
            newPayment.walletName = walletKind;
            newPayment.walletImage = walletImageNew;
            newPayment.walletId = walletIdNew;



            HttpClient http = new HttpClient();
            var chuoi = http.PostAsync("http://webapimoneyplus.somee.com/api/XuLyController/CreatePayment?PaymentImg=" + newPayment.PaymentImg + "&PaymentTime=" + newPayment.PaymentTime + "&PaymentMoney=" + newPayment.PaymentMoney + "&PaymentTitle=" + newPayment.PaymentTitle + "&PaymentWallet=" + newPayment.PaymentWallet + "&PaymentNote=" + newPayment.PaymentNote + "&walletImage=" + newPayment.walletImage + "&walletName=" + newPayment.walletName + "&walletId=" + newPayment.walletId, null);
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (walletNew.change_wallet)
                PickAccountInit(walletNew.walletPublic);
            memberIcon = memberChosen.img;
            memberTitle = memberChosen.str;
            pickMember.ImageSource = memberIcon;
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

        private void onSelectOperator_Clicked(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }


        private void pickAccount_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(walletNew);
        }

        private void pickMember_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new pickMember());
        }

        private void pickDate_Clicked(object sender, EventArgs e)
        {
           
        }

        private void pickcalculationPoint_Clicked(object sender, EventArgs e)
        {

        }

        private void income03_Clicked(object sender, EventArgs e)
        {
            title = "Tiền công";
            img = "sachbotui_income_03.png";
        }

        private void income05_Clicked(object sender, EventArgs e)
        {
            title = "Tiền thưởng";
            img = "sachbotui_income_05.png";
        }

        private void income07_Clicked(object sender, EventArgs e)
        {
            title = "Đầu tư";
            img = "sachbotui_income_07.png";
        }

        private void income09_Clicked(object sender, EventArgs e)
        {
            title = "Bán thời gian";
            img = "sachbotui_income_09.png";
        }

        private void pickDelete_Clicked(object sender, EventArgs e)
        {
            if (resultText.Text != string.Empty)
            {
                int resultLength = resultText.Text.Length;
                if (resultLength != 1)
                {
                    resultText.Text = resultText.Text.Remove(resultLength - 1);
                }
                else
                {
                    resultText.Text = 0.ToString();
                }
            }
        }

        private async void expend_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addNewPaymentPage());

        }


        private async void tranfer_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new addNewTranferPage());
        }

    }
}