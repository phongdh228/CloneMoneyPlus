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
    public partial class Pocketbook : ContentPage
    {
        public Pocketbook()
        {
            InitializeComponent();
            HienThiPayments();
            TotalInit();
        }
        async void HienThiPayments()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            var dspayment = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            lstPayment.ItemsSource = dspayment;
        }

        int income = 0, outcome = 0;
        async void TotalInit()
        {
            List<Payment> paymentMain = new List<Payment>();
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            var dspayment = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            List<Payment> paymentOthers = dspayment;


            foreach (Payment payment in paymentOthers)
            {
                var paymentId = payment.PaymentId;
                var chuoi2 = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPaymentById?PaymentId=" + paymentId.ToString());
                var dspayment2 = JsonConvert.DeserializeObject<List<Payment>>(chuoi2);
                List<Payment> temp = dspayment2;
                if (temp.Count > 0)
                {
                    paymentMain.Add(temp.ElementAt(0));
                    string money = temp.ElementAt(0).PaymentMoney;
                    income += Int32.Parse(money);
                    if (Int32.Parse(temp.ElementAt(0).PaymentMoney) < 0)
                    {
                        outcome += Int32.Parse(money);
                    }
                }
            };
            lstPayment.ItemsSource = paymentMain;
            outcomeMoney.Text = "$" + outcome;
            //totalPrice2.Text = "$" + (total - debit).ToString();
            incomeMoney.Text = "$" + income;

            //Date appearance handling (fake time)
            string localTime = DateTime.Now.ToString("yyyy-MM");
            datetime.Text = localTime;
            //datetime.Text = PaymentTime.ToString("yyyy-MM");
        }

        //void PaymentInit()
        //{
        //    Database db = new Database();
        //    List<Payment> payments = db.GetPayments();
        //    lstPayment.ItemsSource = payments;
        //}


        //void PaymentInit()
        //{
        //    Database db = new Database();
        //    List<Payment> payments = db.GetPayments();
        //    lstPayment.ItemsSource = payments;
        //}

        private void newPayment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewPaymentPage());
        }

        private async void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Payment selectedPayment = e.SelectedItem as Payment;
            await PopupNavigation.Instance.PushAsync(new PopupPayment(selectedPayment));
        }
        private void calendarButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PocketCalendar());
        }
    }
}