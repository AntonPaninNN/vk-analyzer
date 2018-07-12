using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkHistory.HistoryData
{
    public abstract class IHistoryData
    {
        private string coreId = string.Empty;

        public string CoreId { get { return coreId; } set { coreId = value; } }
    }
}
