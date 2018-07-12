using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using VkAnalyzer.Enums;

namespace VkAnalyzer.Charts.Impl
{
    class PieChartBuilder : IChartBuilder
    {
        public override void buildChart(Chart chart, 
            SortedDictionary<string, int> data, string chartName)
        {
            chart.Series.Clear();
            chart.Titles.Add(chartName);
            Series series = new Series();
            series.Name = "general";
            series.IsVisibleInLegend = true;
            series.ChartType = SeriesChartType.Pie;

            int count = 0;
            foreach (KeyValuePair<string, int> pair in data)
            {
                series.Points.Add(pair.Value);
                var point = series.Points[count];
                point.Color = CommonMaps.ChartColorMap[count];
                point.AxisLabel = pair.Key;
                point.LegendText = pair.Key;
                point.Label = pair.Key;
                count++;
            }
            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.Interval = 1;
        }

        public override void buildChart()
        {
            throw new NotImplementedException();
        }
    }
}
