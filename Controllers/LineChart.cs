namespace EasyChartBuySell.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Plotly.Blazor;
    using Plotly.Blazor.LayoutLib;
    using Plotly.Blazor.LayoutLib.XAxisLib;
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
            XAxis = new List<XAxis>
            {
                new XAxis
                {
                    //AutoRange = AutoRangeEnum.True,
                    // Domain = new List<object> {0, 1},
                    Range = new List<object> {DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1)}, // "2021-05-25 12:00"
                    RangeSlider = new RangeSlider
                    {
                        //Range = new object[] {"2021-05-25 12:00", "2021-05-25 12:00"}
                    },
                    // Title = new Plotly.Blazor.LayoutLib.XAxisLib.Title
                    // {
                    //     Text = "Date"
                    // },
                    Type = TypeEnum.Date
                }
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

        IList<ITrace> buyData = new List<ITrace>
        {
            new Scatter
            {
                Name = "Buy",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = new List<object>(),
                Y = new List<object>()
            }
        };

        public async Task ShowChartData(List<string> parsedDataList)
        {
            if (!(chart.Data.FirstOrDefault() is Scatter scatter)) return;

            var x = new List<object>();
            var y = new List<object>();

            foreach (var item in parsedDataList)
            {
                y.Add(item);
            }

            var startDate = new DateTime();
            startDate = DateTime.Parse(Helper.ETHStartDate);
            
            var time = 0;
            for (int i = 0; i < parsedDataList.Count; i++)
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

        public async Task RenderSavedUserData(double buyPrice, double buyAmount, DateTime dateBought) 
        {
            var x = new List<object>();
            var y = new List<object>();

            // Buy price 
            y.Add(buyPrice);

            // At time
            x.Add(dateBought);

            var scatter = new Scatter
            {
                Name = $"{dateBought}",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = x,
                Y = y,
            };

            await chart.AddTrace(scatter);
        }

        public async Task UpdateUserData(double buyPrice, double buyAmount, DateTime dateBought, bool userHasSavedData)
        {
            var x = new List<object>();
            var y = new List<object>();

            // Buy price 
            y.Add(buyPrice);

            // At time
            x.Add(dateBought);

            var scatter = new Scatter
            {
                Name = $"{dateBought}",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = x,
                Y = y,
            };

            await chart.ExtendTrace(x, y, data.IndexOf(scatter));
        }

        public async Task AddUserData(Helper.ChartStruct cStruct, bool userHasSavedData)
        {
            var x = new List<object>();
            var y = new List<object>();

            // Buy price 
            y.Add(cStruct.buyPrice);

            // At time
            x.Add(cStruct.dateBought);

            var scatter = new Scatter
            {
                Name = $"{cStruct.dateBought}",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = x,
                Y = y,
            };

            if (!userHasSavedData)
            {
                await chart.AddTrace(scatter);//x, y, data.IndexOf(scatter));
            }
            else
            {
                await chart.ExtendTrace(x, y, data.IndexOf(scatter));
            }
        }

        public async Task AddUserData(double buyPrice, double buyAmount, DateTime dateBought, bool userHasSavedData)
        {
            var x = new List<object>();
            var y = new List<object>();

            // Buy price 
            y.Add(buyPrice);

            // At time
            x.Add(dateBought);

            var scatter = new Scatter
            {
                Name = $"{dateBought}",
                Mode = ModeFlag.Lines | ModeFlag.Markers,
                X = x,
                Y = y,
            };

            if (!userHasSavedData)
            {
                await chart.AddTrace(scatter);//x, y, data.IndexOf(scatter));
            }
            else
            {
                await chart.ExtendTrace(x, y, data.IndexOf(scatter));
            }
        }
    }
}