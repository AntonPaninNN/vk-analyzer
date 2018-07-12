using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VkAnalyzer.Presenters.Impl
{
    class TextBoxConsolePresenter : IConsolePresenter
    {
        private TextBoxConsolePresenter() {}

        private static TextBoxConsolePresenter _instance = null;

        public static TextBoxConsolePresenter getInstance(TextBox textBoxConsole, Form invokeForm)
        {
            if (_instance == null)
                _instance = new TextBoxConsolePresenter();

            _instance._textBoxConsole = textBoxConsole;
            _instance._invokeForm = invokeForm;

            return _instance;
        }

        private TextBox _textBoxConsole = null;
        private Form _invokeForm = null;

        public override void clearConsole()
        {
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                _textBoxConsole.Clear();
            });
        }

        public override void appendConsole(List<string> lines)
        {
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                if (_textBoxConsole.Multiline)
                {
                    foreach (string line in lines)
                    {
                        _textBoxConsole.AppendText(Environment.NewLine);
                        _textBoxConsole.AppendText(line);
                    }
                }
            });
        }

        public override void appendLineToConsole(string line)
        {
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                _textBoxConsole.AppendText(Environment.NewLine);
                _textBoxConsole.AppendText(line);
            });
        }

        public override List<string> getAllFromConsole()
        {
            List<string> lines = new List<string>();
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                foreach (string line in _textBoxConsole.Lines)
                    lines.Add(line);
            });
            return lines;
        }

        public override string getLineFromConsole(int lineIndex)
        {
            string line = string.Empty;
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                line = _textBoxConsole.Lines[lineIndex];
            });
            return line;
        }

        public override List<string> getRangeFromConsole(int from, int to)
        {
            List<string> lines = new List<string>();
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                string[] linesArr = _textBoxConsole.Lines;
                for (int i = from; i < to; i++)
                    lines.Add(linesArr[i]);
            });
            return lines;
        }

        public override bool containsItem(string line)
        {
            bool result = false;
            _invokeForm.Invoke((MethodInvoker)delegate()
            {
                result = _textBoxConsole.Lines.Contains(line);
            });
            return result;
        }
    }
}
