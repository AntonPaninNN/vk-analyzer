using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace VkAnalyzer.State
{
    class ChartGlobalMap
    {
        private ChartGlobalMap()
        { }

        private static ChartGlobalMap _gMap = null;

        public static ChartGlobalMap getInstance()
        {
            if (_gMap == null)
                _gMap = new ChartGlobalMap();

            return _gMap;
        }

        public void initCurrentCharts()
        {
            currentCharts = new Dictionary<string, Chart>();
        }

        public void deinitCurrentCharts()
        {
            currentCharts = null;
        }

        private Dictionary<string, Chart> currentCharts = null;
        public Dictionary<string, Chart> CurrentCharts
        { get { return currentCharts; } set { currentCharts = value; } }
    }
}
