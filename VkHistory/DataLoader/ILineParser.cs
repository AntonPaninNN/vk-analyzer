using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkHistory.DataLoader
{
    interface ILineParser
    {
        string parseLine(string line);
    }
}
