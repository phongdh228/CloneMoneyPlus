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
    public partial class addNewTranferPage : ContentPage
    {
        PickWalletAccount walletNew = new PickWalletAccount();
        public addNewTranferPage()
        {
            InitializeComponent();
        }

        double money = 0;
        string title = "Chế độ ăn", img = "sachbotui_expend_01.png", walletKind = "Sổ cái mặc định";
        DateTime date = DateTime.Today;

        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        public int walletIdNew;
        public string walletImageNew;
        async void PickAccountInit(WalletInfo wallet)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWalletTheoId?Id=" + wallet.Id);
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);

            
            pickWalletAccount01.ImageSource = dswallet.ElementAt(0).walletImg;
            walletImageNew = dswallet.ElementAt(0).walletImg;
            walletKind = dswallet.ElementAt(0).walletName;
            walletIdNew = dswallet.ElementAt(0).Id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (walletNew.change_wallet)
                PickAccountInit(walletNew.walletPublic);
        }
        private void pickDate_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationPoint_Clicked(object sender, EventArgs e)
        {

        }

        private void pickDelete_Clicked(object sender, EventArgs e)
        {

        }

        private async void expend_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addNewPaymentPage());
        }

        private async void income_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addNewIncome());

        }

        private void confirm_Clicked(object sender, EventArgs e)
        {

        }


        private void pickWalletAccount01_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(walletNew);
        }

        private void pickWalletAccount02_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(walletNew);
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
    }
}