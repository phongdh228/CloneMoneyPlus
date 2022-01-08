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
    public partial class AnalyTrendPage : ContentPage
    {
        List<Payment> payments = new List<Payment>();
        int start = 0;
        int lenght = 0;
        AnalyByDay[] amountDaily;
        public AnalyTrendPage()
        {
            InitializeComponent();
            GetData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetData();
            InitTrends();
            InitList();
        }

        async void GetData()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            payments = JsonConvert.DeserializeObject<List<Payment>>(chuoi);
        }

        void InitTrends()
        {
            start = int.Parse(payments.First().PaymentTime.Day.ToString());
            int end = int.Parse(payments.Last().PaymentTime.Day.ToString());
            lenght = end - start + 1;
            amountDaily = new AnalyByDay[lenght];
            for (int j = 0; j < lenght; j++)
            {
                amountDaily[j] = new AnalyByDay();
            }
            int DayStart = int.Parse(payments.FirstOrDefault().PaymentTime.Day.ToString());
            for (int j = 0; j < lenght; j++)
            {
                amountDaily[j].analyDay = (DayStart + j).ToString() + " - " + payments.ElementAt(j).PaymentTime.Month.ToString();
            }
            foreach (Payment payment in payments)
            {
                int money = int.Parse(payment.PaymentMoney);
                int date = int.Parse(payment.PaymentTime.Day.ToString());
                if (money > 0)
                    amountDaily[date - start].analyIncome += money;
                else
                    amountDaily[date - start].analyExpense += Math.Abs(money);
            }

            var incomeEntries = new List<ChartEntry>();
            var expenseEntries = new List<ChartEntry>();

            for (int i = 0; i < lenght; i++)
            {
                incomeEntries.Add(new ChartEntry(amountDaily[i].analyIncome)
                {
                    Color = SKColor.Parse("#63f3ad"),
                    ValueLabel = " ",
                    Label = amountDaily[i].analyDay
                });
                expenseEntries.Add(new ChartEntry(amountDaily[i].analyExpense)
                {
                    Color = SKColors.White,
                    Label = amountDaily[i].analyDay
                });
                amountDaily[i].analyTotal = amountDaily[i].analyIncome - amountDaily[i].analyExpense;
            }

            chartIncomeBar.Chart = new LineChart { Entries = incomeEntries,
                BackgroundColor = SKColor.Empty, LabelTextSize = 36,
                ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal,
                LineSize = 10,
                PointSize = 30,
                LabelColor = SKColors.White
            };
            chartExpenseBar.Chart = new LineChart { Entries = expenseEntries,
                BackgroundColor = SKColor.Empty, LabelTextSize = 36,
                ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal,
                LineSize = 10,
                PointSize = 30
            };
        }

        void InitList()
        {
            lstPayment.ItemsSource = null;
            lstPayment.ItemsSource = amountDaily;
        }

        private void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}