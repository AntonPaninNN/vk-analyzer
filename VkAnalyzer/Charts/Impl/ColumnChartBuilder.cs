using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace VkAnalyzer.Charts.Impl
{
    class ColumnChartBuilder : IChartBuilder
    {
        private readonly int MAX_COUNT = 30;

        public override void buildChart(Chart chart, 
            SortedDictionary<string, int> data, string chartName)
        {
            var sortedDict =
                from entry in data orderby entry.Value descending select entry;
            
            chart.Series.Clear();
            chart.Titles.Add(chartName);
            Series series = new Series();
            series.Name = "general";
            series.IsVisibleInLegend = false;
            series.ChartType = SeriesChartType.Column;

            int count = 0;
            foreach (KeyValuePair<string, int> pair in sortedDict)
            {
                series.Points.Add(pair.Value);
                var point = series.Points[count];
                point.Color = Color.Green;
                point.AxisLabel = pair.Key;
                point.LegendText = pair.Key;
                point.Label = pair.Value.ToString();
                count++;

                if (count >= MAX_COUNT)
                    break;
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
