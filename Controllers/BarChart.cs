namespace EasyChartBuySell.Controllers
{
    using System.Collections.Generic;
    using Plotly.Blazor;
    using Plotly.Blazor.LayoutLib;

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
    }
}