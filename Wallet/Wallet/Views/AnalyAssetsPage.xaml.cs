using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microcharts;
using SkiaSharp;
using System.Net.Http;
using Newtonsoft.Json;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalyAssetsPage : ContentPage
    {
        List<Payment> payments = new List<Payment>();
        List<WalletInfo> wallets = new List<WalletInfo>();
        AnalyByDay[] amountDaily;
        int totalMoney;
        int start = 0;
        int lenght = 0;
        public AnalyAssetsPage()
        {
            InitializeComponent();
            GetWallet();
            InitTotalMoney();
            GetPayments();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetWallet();
            InitTotalMoney();
            GetPayments();
            InitAssets();
            InitList();
        }

        async void GetWallet()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWallet");
            wallets = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi); 
        }

        void InitTotalMoney()
        {
            totalMoney = 0;
            foreach (var wallet in wallets)
            {
                totalMoney += wallet.walletPrice;
            }
        }

        async void GetPayments()
        {
                HttpClient http = new HttpClient();
                var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
                payments = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
        }

        void InitAssets()
        {
            start = int.Parse(payments.First().PaymentTime.Day.ToString());
            int end = int.Parse(payments.Last().PaymentTime.Day.ToString());
            lenght = end - start + 1;
            amountDaily = new AnalyByDay[lenght + 1];
            for (int i = 0; i < lenght + 1; i++)
            {
                amountDaily[i] = new AnalyByDay();
            }
            int DayStart = int.Parse(payments.FirstOrDefault().PaymentTime.Day.ToString()) - 1;
            for (int j = 0; j <= lenght; j++)
            {
                amountDaily[j].analyDay = (DayStart + j).ToString() + " - " + payments.ElementAt(j).PaymentTime.Month.ToString();
            }
            amountDaily[0].analyTotal = totalMoney;
            foreach (Payment payment in payments)
            {
                int money = int.Parse(payment.PaymentMoney);
                int date = int.Parse(payment.PaymentTime.Day.ToString());
                amountDaily[date-start + 1].analyChange += money;
            }

            for (int i = 0; i < lenght; i++)
            {
                amountDaily[i + 1].analyTotal = amountDaily[i].analyTotal + amountDaily[i + 1].analyChange;
            }

            var entries = new List<ChartEntry>();

            for (int i = 0; i <= lenght; i++)
            {
                entries.Add(new ChartEntry(amountDaily[i].analyTotal)
                {
                    Color = SKColor.Parse("#63f3ad"),
                    ValueLabel = " ",
                    Label = amountDaily[i].analyDay
                });
            }

            var chart = new LineChart { Entries = entries, LabelTextSize = 36,
                ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal,
                LabelColor = SKColors.White, BackgroundColor = SKColor.Empty, LineSize = 10, PointSize = 30 };
            chartViewBar.Chart = chart;
        }

        void InitList()
        {
            lstPayment.ItemsSource = null;
            lstPayment.ItemsSource = amountDaily;
        }
    }
}