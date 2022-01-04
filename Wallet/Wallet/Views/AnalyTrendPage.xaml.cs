using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microcharts;
using SkiaSharp;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalyTrendPage : ContentPage
    {
        public AnalyTrendPage()
        {
            InitializeComponent();
        }
        public MultiLineChart multiLines;
        private string[] months = new string[] { "JAN", "FRB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

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
        }
    }
}