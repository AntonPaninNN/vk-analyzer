using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace VkAnalyzer.Charts
{
    abstract class IChartBuilder
    {
        public abstract void buildChart(Chart chart,
            SortedDictionary<string, int> data, string chartName);

        public abstract void buildChart();
    }
}
