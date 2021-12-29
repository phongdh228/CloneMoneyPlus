using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            totalPrice.Text = analyIE.iePrice.ToString() + "đ";
            InitList(analyIE.ieTitle);
        }

        public async void InitList(string Title)
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            var payments = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
            List<Payment> list = new List<Payment>();
            if (payments != null)
                foreach (Payment payment in payments)
                {
                    if (payment.PaymentTitle == Title)
                        list.Add(payment);
                }
            lstPayment.ItemsSource = list;
        }
    }
}