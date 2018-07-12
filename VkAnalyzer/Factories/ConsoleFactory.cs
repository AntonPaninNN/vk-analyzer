using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkAnalyzer.Presenters;
using VkAnalyzer.Presenters.Impl;
using System.Windows.Forms;

namespace VkAnalyzer.Factories
{
    class ConsoleFactory
    {
        public static IConsolePresenter getConsolePresenter(object console, Form invokeForm, ConsoleType cType)
        {
            if (cType == ConsoleType.TextBox)
                return TextBoxConsolePresenter.getInstance((TextBox)console, invokeForm);
            else
                return null;
        }
    }
}
