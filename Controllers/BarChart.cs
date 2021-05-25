namespace EasyChartBuySell.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Plotly.Blazor;
    using Plotly.Blazor.LayoutLib;
    using Plotly.Blazor.Traces;

    public class BarChart
    {
        public PlotlyChart barChart;

        public Config barConfig = new Config
        {
            Responsive = true
        };

        public Layout barLayout = new Layout
        {
            Title = new Title
            {
                Text = "Your assets"
            },
            BarMode = BarModeEnum.Stack,
            Height = 300
        };

        public List<ITrace> barDataTrace = new List<ITrace>
        {
            /// Example use
            // new Bar
            // {
            //     X = new List<object> {"ETH"},
            //     Y = new List<object> {0.1},
            //     Name = "Bought ETC at" + DateTime.Now
            // },
            // new Bar
            // {
            //     X = new List<object> {"ETH"},
            //     Y = new List<object> {0.5},
            //     Name = "Bought ETH at" + DateTime.Now
            // }
        };

        public Bar bar = new Bar();

        public async Task BuyIncreaseBarChart(double buyAmount, DateTime dateBought)
        {
            bar.X = new List<object> { "ETH" };
            bar.Y = new List<object> { buyAmount };
            bar.Name = "Bought ETH at " + dateBought;

            barDataTrace.Add(bar);

            await barChart.React();
        }
    }
}