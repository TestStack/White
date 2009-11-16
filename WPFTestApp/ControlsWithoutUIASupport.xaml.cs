using System;
using Visifire.Charts;
using White.WPFCustomControls;

namespace WindowsPresentationFramework
{
    public partial class ControlsWithoutUIASupport
    {
        private readonly Random rand = new Random(DateTime.Now.Millisecond);

        public ControlsWithoutUIASupport()
        {
            InitializeComponent();
            CreateChart();
        }

        private void CreateChart()
        {
            var chart = new WhiteChart {Name = "foobar"};
            var title = new Title {Text = "Visifire Sample Chart"};
            chart.Titles.Add(title);

            chart.Series.Add(GetDataSeries());
            chart.Series.Add(GetDataSeries());
            LayoutRoot.Children.Add(chart);
        }

        private DataSeries GetDataSeries() {
            var dataSeries = new DataSeries {RenderAs = RenderAs.Column};
            for (int i = 0; i < 10; i++)
            {
                var dataPoint = new DataPoint {YValue = rand.Next(-100, 100)};
                dataSeries.DataPoints.Add(dataPoint);
            }
            return dataSeries;
        }
    }
}