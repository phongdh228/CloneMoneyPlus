using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PocketCalendar : ContentPage
    {
        public PocketCalendar()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<App>((App)Application.Current, "OnCategoryCreated", (sender) => {
                HienThiPayments();
                TotalInit();
            });
            HienThiPayments();

        }

        async void HienThiPayments()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            var dspayment = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            lstPayment.ItemsSource = dspayment;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            HienThiPayments();
            TotalInit();
        }
        private async void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Payment selectedPayment = e.SelectedItem as Payment;
            await PopupNavigation.Instance.PushAsync(new PopupPayment(selectedPayment));
        }

        int income, outcome;
        async void TotalInit()
        {
            List<Payment> paymentMain = new List<Payment>();
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            var dspayment = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            List<Payment> paymentOthers = dspayment;

            income = 0;
            outcome = 0;

            foreach (Payment payment in paymentOthers)
            {

                paymentMain.Add(payment);
                string money = payment.PaymentMoney;

                if (Int32.Parse(payment.PaymentMoney) < 0)
                {
                    outcome += Int32.Parse(money);
                }
                else
                {
                    income += Int32.Parse(money);
                }

            };
            lstPayment.ItemsSource = paymentMain;
            //using ToString("#,##0") to get currency format
            outcomeMoney.Text = "$" + Math.Abs(outcome).ToString("#,##0");
            incomeMoney.Text = "$" + income.ToString("#,##0");

            //Date appearance handling (fake time)
            string localTime = DateTime.Now.ToString("yyyy-MM");
            datetime.Text = localTime;
            //datetime.Text = paymentMain.PaymentTime.ToString("yyyy-MM");
        }
        private void billButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Pocketbook());
        }
    }
}