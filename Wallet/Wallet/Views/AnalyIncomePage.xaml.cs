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
    public partial class AnalyIncomePage : ContentPage
    {
        List<AnalyIE> IncomeList = new List<AnalyIE>();
        List<AnalyIE> ListToShow = new List<AnalyIE>();
        List<Payment> payments = new List<Payment>();
        int TotalPrice = 0;
        public AnalyIncomePage()
        {
            InitializeComponent();
            InitIncome();
            GetData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetData();
            CountPrice();
            InitChart();
            InitList();
        }

        protected void InitIncome()
        {
            IncomeList.Add(new AnalyIE { ieImg = "sachbotui_income_03.png", ieTitle = "Tiền công", iePrice = 0, ieColor = "#f44336" });
            IncomeList.Add(new AnalyIE { ieImg = "sachbotui_income_05.png", ieTitle = "Tiền thưởng", iePrice = 0, ieColor = "#e91e63" });
            IncomeList.Add(new AnalyIE { ieImg = "sachbotui_income_07.png", ieTitle = "Đầu tư", iePrice = 0, ieColor = "#9c27b0" });
            IncomeList.Add(new AnalyIE { ieImg = "sachbotui_income_09.png", ieTitle = "Bán thời gian", iePrice = 0, ieColor = "#673ab7" });
        }

        async void GetData()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            payments = JsonConvert.DeserializeObject<List<Payment>>(chuoi);

        }

        void CountPrice()
        {
            foreach (AnalyIE Income in IncomeList)
            {
                Income.iePrice = 0;
            }
            if (payments != null)
                foreach (Payment payment in payments)
                {
                    if (int.Parse(payment.PaymentMoney) > 0)
                    {
                        foreach (AnalyIE Income in IncomeList)
                        {
                            if (Income.ieTitle == payment.PaymentTitle)
                            {
                                Income.iePrice += Math.Abs(int.Parse(payment.PaymentMoney));
                                break;
                            }
                        }
                    }
                }
            ListToShow.Clear();
            TotalPrice = 0;
            if (IncomeList != null)
                foreach (AnalyIE Income in IncomeList)
                {
                    TotalPrice += Income.iePrice;
                    if (Income.iePrice != 0)
                    {
                        ListToShow.Add(Income);
                    }
                }
            if (ListToShow != null)
                foreach (AnalyIE Income in ListToShow)
                {
                    float price = (float)Income.iePrice * 100 / TotalPrice;
                    if (price < 1)
                        Income.iePercent = "0" + string.Format("{0:#.##}", price) + " %";
                    else
                        Income.iePercent = string.Format("{0:#.##}", price) + " %";
                }
        }

        protected void InitChart()
        {
            List<ChartEntry> entries = new List<ChartEntry>();
            if (ListToShow != null)
                foreach (AnalyIE Expense in ListToShow)
                {
                    entries.Add(new ChartEntry(Expense.iePrice)
                    {
                        Label = Expense.ieTitle,
                        ValueLabel = Expense.iePrice.ToString(),
                        Color = SKColor.Parse(Expense.ieColor),
                        ValueLabelColor = SKColor.Parse(Expense.ieColor)
                    });
                }
            var chart = new DonutChart { Entries = entries, HoleRadius = (float)0.55, LabelTextSize = 36 };

            chartViewBar.Chart = chart;
        }

        public void InitList()
        {
            lstIncome.ItemsSource = null;
            lstIncome.ItemsSource = ListToShow;
        }

        private void lstIncome_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new AnalyIEDetail(e.SelectedItem as AnalyIE));
        }
    }
}