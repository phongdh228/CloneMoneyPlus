using System;
using System.Collections.Generic;
using System.Text;

using Microcharts;
using SkiaSharp;
using System.Linq;
using Xamarin.Forms.Internals;

using Entry = Microcharts.ChartEntry;
using LineChart = Microcharts.LineChart;

namespace Wallet
{
    public class MultiLineChart : LineChart
    {
        public List<List<Entry>> multiline_entries { get; set; }

        public List<String> legend_names { get; set; }

        private bool inited = false;

        private float multiline_min;
        private float multiline_max;


        private void init()
        {
            if (inited)
            {
                return;
            }

            inited = true;

            foreach (List<Entry> l in multiline_entries)
            {
                foreach (Entry e in l)
                {
                    if (e.Value > multiline_max)
                    {
                        multiline_max = e.Value;
                    }
                    if (e.Value < multiline_min)
                    {
                        multiline_min = e.Value;
                    }
                }
            }
        }

        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            init();

            drawLegend(canvas);

            Entries = multiline_entries[0];
            //var valueLabelSizes = 30;
            var footerHeight = 200;
            var headerHeight = 200;
            var itemSize = CalculateItemSize(width, height, footerHeight, headerHeight);
            var origin = CalculateYOrigin(itemSize.Height, headerHeight);
            var valueLabelSizes = MeasureLabels(multiline_entries.ElementAt(0).Select(x => x.Label).ToArray());

            foreach (List<Entry> l in multiline_entries)
            {
                Entries = l;
                var points = this.CalculateMultilinePoints(itemSize, origin, headerHeight);

                this.DrawLine(canvas, points, itemSize);
                this.DrawPoints(canvas, points);

                if (multiline_entries.IndexOf(l) == 0)
                {
                    DrawArea(canvas, points, itemSize, origin);
                    DrawFooter(canvas, l.Select(x => x.Label).ToArray(), valueLabelSizes, points, itemSize, height, footerHeight);
                }
            }
        }


        private void drawLegend(SKCanvas canvas)
        {
            if (!legend_names.Any()) { return; }

            List<SKColor> colors = new List<SKColor> { };

            foreach (List<Entry> l in multiline_entries)
            {
                colors.Add(l[0].Color);
            }

            int radius_size = 20;

            using (var paint = new SKPaint())
            {
                paint.TextSize = this.LabelTextSize;
                paint.IsAntialias = true;
                paint.IsStroke = false;

                float x = radius_size * 2;
                float y = 50;

                foreach (String legend in legend_names)
                {
                    paint.Color = SKColor.Parse("#000000");
                    canvas.DrawText(legend, x + radius_size, y, paint);

                    paint.Color = colors.ElementAt(legend_names.IndexOf(legend));
                    canvas.DrawCircle(x, y - radius_size / 2 - radius_size / 4, radius_size, paint);

                    x += radius_size * 2 + this.LabelTextSize * (legend.Length / 2 + 2);
                }
            }
        }

        private SKPoint[] CalculateMultilinePoints(SKSize itemSize, float origin, float headerHeight)
        {
            var result = new List<SKPoint>();

            for (int i = 0; i < this.Entries.Count(); i++)
            {
                var entry = this.Entries.ElementAt(i);

                var x = this.Margin + (itemSize.Width / 2) + (i * (itemSize.Width + this.Margin));
                var y = headerHeight + (((multiline_max - entry.Value) / (multiline_max - multiline_min)) * itemSize.Height);
                var point = new SKPoint(x, y);
                result.Add(point);
            }

            return result.ToArray();
        }
    }
}