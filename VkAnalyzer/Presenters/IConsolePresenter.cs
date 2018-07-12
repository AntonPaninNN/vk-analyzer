using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkAnalyzer.Presenters
{
    abstract class IConsolePresenter
    {
        public abstract void clearConsole();

        public abstract void appendConsole(List<string> lines);

        public abstract void appendLineToConsole(string line);

        public abstract List<string> getAllFromConsole();

        public abstract string getLineFromConsole(int lineIndex);

        public abstract List<string> getRangeFromConsole(int from, int to);

        public abstract bool containsItem(string line);
    }
}
