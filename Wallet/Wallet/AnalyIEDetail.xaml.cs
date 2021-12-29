using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalyIEDetail : ContentPage
    {
        public AnalyIEDetail()
        {
            InitializeComponent();
        }

        public AnalyIEDetail(AnalyIE analyIE)
        {
            InitializeComponent();
            ieTitle.Text = analyIE.ieTitle;
            totalPrice.Text = analyIE.iePrice.ToString()+"đ";
            InitList(analyIE.ieTitle);
        }

        public void InitList(string Title)
        {
            Database db = new Database();
            List<Payment> payments = db.GetPayments();
            List<Payment> list = new List<Payment>();
            if (payments!=null)
                foreach (Payment payment in payments)
                {
                    if (payment.PaymentTitle == Title)
                        list.Add(payment);
                }
            lstPayment.ItemsSource = list;
        }
    }
}