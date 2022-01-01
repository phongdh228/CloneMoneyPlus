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
            MessagingCenter.Subscribe<App>((App)Application.Current, "OnCategoryCreated", (sender) => {
                HienThiPayments();
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