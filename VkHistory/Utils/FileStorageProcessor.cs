using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkHistory.DataLoader;
using VkHistory.DataLoader.Impl;
using System.IO;

namespace VkHistory.Utils
{
    class FileStorageProcessor
    {
        private static ILineParser htmlParser = new HtmlLineParser();
        private static ILineParser txtParser = new TextLineParser();

        public static string parseLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return null;
            if (line.Contains("a href"))
                return htmlParser.parseLine(line);
            else
                return txtParser.parseLine(line);
        }

        public static List<string> getLines(string directoryName)
        {
            List<string> lines = new List<string>();
            var filePaths = Directory.GetFiles(directoryName, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".html") || s.EndsWith(".htm") || s.EndsWith(".txt"));
            foreach (string filePath in filePaths)
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line = string.Empty;
                    while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                    {
                        line = parseLine(line);
                        if (!string.IsNullOrEmpty(line))
                            lines.Add(line);
                    }
                }
            }

            return lines;
        }
    }
}
