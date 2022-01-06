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
        AnalyExpensePage analyExpense = new AnalyExpensePage();
        List<Payment> payments = new List<Payment>();
        List<WalletInfo> wallets = new List<WalletInfo>();
        string[] ChartDates;
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
            int end = int.Parse(payments.LastOrDefault().PaymentTime.Day.ToString());
            lenght = end - start + 1;
            ChartDates = new string[lenght + 1]; //Thêm 1 ngày trước cho số tiền khởi điểm
            int DayStart = int.Parse(payments.FirstOrDefault().PaymentTime.Day.ToString()) - 1;
            for (int j = 0; j <= lenght; j++)
            {
                ChartDates[j] = (DayStart + j).ToString() + " - " + payments.ElementAt(j).PaymentTime.Month.ToString();
            }
            int[] changes = new int[lenght];
            int[] final = new int[lenght + 1]; //0 là của số tiền khởi điểm nên lệch giá trị biến động 1 index
            final[0] = totalMoney;
            foreach (Payment payment in payments)
            {
                int money = int.Parse(payment.PaymentMoney);
                int date = int.Parse(payment.PaymentTime.Day.ToString());
                changes[date-start] += money;
            }

            for (int i = 0; i < lenght; i++)
            {
                final[i + 1] = final[i] + changes[i];
            }

            var entries = new List<ChartEntry>();

            for (int i = 0; i <= lenght; i++)
            {
                entries.Add(new ChartEntry(final[i])
                {
                    Color = SKColor.Parse("#0000FF"),
                    ValueLabel = final[i].ToString(),
                    Label = ChartDates[i]
                });
            }

            var chart = new LineChart { Entries = entries, LabelTextSize = 36, ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal };
            chartViewBar.Chart = chart;
        }

        void InitList()
        {
            lstPayment.ItemsSource = null;
            lstPayment.ItemsSource = payments;
        }
    }
}