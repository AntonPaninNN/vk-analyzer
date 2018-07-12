using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkAnalyzer.Helpers;
using VkAnalyzer.State;
using VkAnalyzer.Charts.Impl;
using System.Windows.Forms.DataVisualization.Charting;

namespace VkAnalyzer.Charts
{
    class ChartBuilderFactory
    {
        public static IChartBuilder getChartBuilder(string param, Chart chart)
        {
            SortedDictionary<string, int> dictionary =
                ChartHelper.prepareChartData(GlobalContext.getInstance().CurrentUsers, param);

            IChartBuilder chartBuilder = null;

            if (param.Equals("City") || param.Equals("BDate") || param.Equals("Family"))
                chartBuilder = new ColumnChartBuilder();
            else
                chartBuilder = new PieChartBuilder();

            chartBuilder.buildChart(chart, dictionary, string.Empty);

            return chartBuilder;
        }
    }
}
