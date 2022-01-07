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
        //MultiLineChart multiLines;
        string[] ChartDates;
        int start = 0;
        int lenght = 0;
        public AnalyTrendPage()
        {
            InitializeComponent();
            GetData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetData();
            InitList();
            InitTrends();

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
            ChartDates = new string[lenght];
            int DayStart = int.Parse(payments.FirstOrDefault().PaymentTime.Day.ToString());
            for (int j = 0; j < lenght; j++)
            {
                ChartDates[j] = (DayStart + j).ToString() + " - " + payments.ElementAt(j).PaymentTime.Month.ToString();
            }
            int[] ListIncome = new int[lenght];
            int[] ListExpense = new int[lenght];
            foreach (Payment payment in payments)
            {
                int money = int.Parse(payment.PaymentMoney);
                int date = int.Parse(payment.PaymentTime.Day.ToString());
                if (money > 0)
                    ListIncome[date - start] += money;
                else
                    ListExpense[date - start] += Math.Abs(money);
            }

            var entries = new List<List<ChartEntry>>();
            var incomeEntries = new List<ChartEntry>();
            var expenseEntries = new List<ChartEntry>();

            int i = 0;
            foreach (var data in ListIncome)
            {
                incomeEntries.Add(new ChartEntry(data)
                {
                    Color = SKColor.Parse("#63f3ad"),
                    ValueLabel = " ",
                    Label = ChartDates[i]
                });
                i++;
            }

            i = 0;
            foreach (var data in ListExpense)
            {
                expenseEntries.Add(new ChartEntry(data)
                {
                    Color = SKColors.White,
                    Label = ChartDates[i]
                });
                i++;
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

            /*entries.Add(incomeEntries);
            entries.Add(expenseEntries);

            multiLines = new MultiLineChart
            {
                multiline_entries = entries,
                LabelTextSize = 30f,
                LabelOrientation = Orientation.Horizontal,
                LineAreaAlpha = 50,
                PointAreaAlpha = 50,
                legend_names = new List<string> { "Thu nhập", "Chi tiêu" },
                IsAnimated = false

            };
            chartViewBar.Chart = multiLines;*/
        }

        void InitList()
        {
            lstPayment.ItemsSource = null;
            lstPayment.ItemsSource = payments;
        }

        private void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /*private string[] months = new string[] { "JAN", "FRB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

        private float[] turnoverData = new float[] { 1000, 5000, 3500, 12000, 9000, 15000, 3000, 0, 0, 0, 0, 0 };
        private float[] chargesData = new float[] { 100, 500, 350, 1200, 900, 1500, 300, 0, 0, 0, 0, 0 };

        private SKColor blueColor = SKColor.Parse("#09C");
        private SKColor redColor = SKColor.Parse("#CC0000");


        private void InitData()
        {
            var entries = new List<List<ChartEntry>>();
            var turnoverEntries = new List<ChartEntry>();
            var chargesEntries = new List<ChartEntry>();

            int i = 0;
            foreach (var data in turnoverData)
            {
                turnoverEntries.Add(new ChartEntry(data)
                {
                    Color = blueColor,
                    ValueLabel = $"{data / 1000} k",
                    Label = months[i]
                });
                i++;
            }

            i = 0;
            foreach (var data in chargesData)
            {
                chargesEntries.Add(new ChartEntry(data)
                {
                    Color = redColor,
                    ValueLabel = $"{data / 1000} k",
                    Label = months[i]
                });
                i++;
            }

            entries.Add(turnoverEntries);
            entries.Add(chargesEntries);

            multiLines = new MultiLineChart
            {
                multiline_entries = entries,
                LabelTextSize = 30f,
                LabelOrientation = Orientation.Horizontal,
                LineAreaAlpha = 50,
                PointAreaAlpha = 50,
                legend_names = new List<string> { "Turnover Chart", "Charges Chart" },
                IsAnimated = false

            };
            chartViewBar.Chart = multiLines;
        }*/
    }
}