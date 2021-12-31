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
    public partial class PopupPayment : Rg.Plugins.Popup.Pages.PopupPage 
    {
        Payment payments;
        public PopupPayment()
        {
            InitializeComponent();
        }
        public PopupPayment(Payment payment)
        {
            InitializeComponent();
            PaymentViewInit(payment);
        }
        async void PaymentViewInit(Payment payment)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPaymentById?PaymentId=" + payment.PaymentId);
            var dspayment = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            lstPayment.ItemsSource = dspayment;
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.DeleteAsync("http://webapimoneyplus.somee.com/api/XuLyController/DeletePayment?PaymentId=" + payments.PaymentId);

            if (chuoi != null)
            {
                DisplayAlert("Thông Báo", "Xóa chi tiêu thành công.", "OK");
                Navigation.PushAsync(new Pocketbook());
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa chi tiêu thất bại", "OK");
            }
        }

        private void edit_Clicked(object sender, EventArgs e)
        {

        }
    }
}