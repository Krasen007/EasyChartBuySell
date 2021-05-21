namespace EasyChartBuySell.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Plotly.Blazor;
    using Plotly.Blazor.LayoutLib;
    using Plotly.Blazor.Traces;
    using Plotly.Blazor.Traces.ScatterLib;

    public class LineChart

    {
        public PlotlyChart chart;

        public Config config = new Config
        {
            Responsive = true
        };

        public Layout layout = new Layout
        {
            Title = new Plotly.Blazor.LayoutLib.Title
            {
                Text = "ETH 1 Hour Chart"
            },
            YAxis = new List<YAxis>
            {
                new YAxis
                {
                    Title = new Plotly.Blazor.LayoutLib.YAxisLib.Title
                    {
                    Text = "USD Price"
                    }
                }
            }
        };

        public IList<ITrace> data = new List<ITrace>
        {
            new Scatter
            {
                Name = "ETH Price",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = new List<object>(),
                Y = new List<object>()
            }
        };

        public async Task ShowData(List<string> dataList)
        {
            if (!(chart.Data.FirstOrDefault() is Scatter scatter)) return;

            var x = new List<object>();
            var y = new List<object>();

            foreach (var item in dataList)
            {
                y.Add(item);
            }

            var startDate = new DateTime(2021, 5, 14, 18, 0, 0);
            var time = 0;
            for (int i = 0; i < dataList.Count; i++)
            {
                x.Add(startDate);
                startDate = startDate.AddHours(1);
                time++;
                if (time == 24)
                {
                    time = 0;
                }
            }

            if (!scatter.X.Any() || !scatter.Y.Any())
            {
                scatter.X.AddRange(x);
                scatter.Y.AddRange(y);
                await chart.React();
            }
            else
            {
                await chart.ExtendTrace(x, y, data.IndexOf(scatter));
            }
        }
        public async Task BuyMoreData(int buyPrice, double buyAmount, DateTime dateBought, IList<ITrace> buyData)
        {
            var x = new List<object>();
            var y = new List<object>();

            // Buy amount
            y.Add(buyPrice);

            // At time
            x.Add(dateBought);

            var scatter = new Scatter
            {
                Name = $"Time Bought{buyData.Count + 1}",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = x,
                Y = y,
            };

            await chart.ExtendTrace(x, y, data.IndexOf(scatter));
        }
    }
}