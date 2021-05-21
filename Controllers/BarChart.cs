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

        public List<ITrace> barData = new List<ITrace>
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

        public async Task BuyIncreaseBarChart(double buyAmount, DateTime dateBought)
        {
            barData.Add(new Bar
            {
                X = new List<object> {"ETH"},
                Y = new List<object> {buyAmount},
                Name = "Bought ETH at " + dateBought
            });

            await barChart.React();
        }
    }
}