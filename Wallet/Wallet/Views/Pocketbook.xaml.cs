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
    public partial class Pocketbook : ContentPage
    {
        public Pocketbook()
        {
            InitializeComponent();
            PaymentInit();
        }

        void PaymentInit()
        {
            Database db = new Database();
            List<Payment> payments = db.GetPayments();
            lstPayment.ItemsSource = payments;
        }

        private void newPayment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewPaymentPage());
        }

        private void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void calendarButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PocketCalendar());
        }
    }
}