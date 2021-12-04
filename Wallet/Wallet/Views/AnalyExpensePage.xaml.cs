using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalyExpensePage : ContentPage
    {
        public AnalyExpensePage()
        {
            InitializeComponent();
            InitChart();
        }

        protected void InitChart()
        {
            var entries = new[]
            {
                new ChartEntry(212)
                {
                    Label = "UWP",
                    ValueLabel = "112",
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(248)
                {
                    Label = "Android",
                    ValueLabel = "648",
                    Color = SKColor.Parse("#77d065")
                },
                new ChartEntry(128)
                {
                    Label = "iOS",
                    ValueLabel = "428",
                    Color = SKColor.Parse("#b455b6")
                },
                new ChartEntry(514)
                {
                    Label = "Forms",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#3498db")
                }
            };
            var chart = new DonutChart { Entries = entries, HoleRadius = (float)0.55, LabelTextSize = 36 };

            chartViewBar.Chart = chart;
        }

        private void lstExpense_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}