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
    public partial class addNewIncome : ContentPage
    {
        public addNewIncome()
        {
            InitializeComponent();
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
            newPayment.PaymentMoney = money.ToString();
            newPayment.PaymentTitle = title;
            newPayment.PaymentNote = paymentNote.Text;
            newPayment.PaymentTime = date;
            newPayment.PaymentWallet = walletKind;


            Database db = new Database();
            if (db.AddNewPayment(newPayment))
            {
                Navigation.PushAsync(new Views.Pocketbook());
            }
            else
            {
                DisplayAlert("Thông báo", "Thêm chi tiêu không thành công.", null, "OK");
                Navigation.PopAsync();
            }
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
            Navigation.PushAsync(new PickWalletAccount());
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

        private void pickDelete_Clicked(object sender, EventArgs e)
        {

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