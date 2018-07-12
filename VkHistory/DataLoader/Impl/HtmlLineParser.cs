using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkHistory.DataLoader.Impl
{
    class HtmlLineParser : ILineParser
    {
        #region ILineParser Members

        public string parseLine(string line)
        {
            return line.Split('\"')[1];
        }

        #endregion
    }
}
