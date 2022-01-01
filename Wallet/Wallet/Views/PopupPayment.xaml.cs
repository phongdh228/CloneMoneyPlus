using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPayment : PopupPage
    {
        Payment payment;

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
            this.payment = payment;
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.DeleteAsync("http://webapimoneyplus.somee.com/api/XuLyController/DeletePayment?PaymentId=" + payment.PaymentId);

            if (chuoi != null)
            {
                DisplayAlert("Thông Báo", "Xóa chi tiêu thành công.", "OK");
                Navigation.PopPopupAsync();
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa chi tiêu thất bại", "OK");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Send<App>((App)Application.Current, "OnCategoryCreated");
        }

        private async void edit_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            Payment item = btn.BindingContext as Payment;
            if (item == null) { return; }
            else
            {
                Navigation.PopPopupAsync();
                await Navigation.PushModalAsync(new NavigationPage(new EditPaymentPage(item)));
         
            }
        }


        private async void turnoff_Clicked(object sender, EventArgs e)
        {
           await PopupNavigation.Instance.PopAsync();
        }

        private void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}