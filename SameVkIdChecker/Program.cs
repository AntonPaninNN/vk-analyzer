using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SameVkIdChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            String dirName = args[0];
            string[] fileNames = Directory.GetFiles(dirName, "*.html", SearchOption.AllDirectories);
            string pathToCompare = args[1];

            List<string> lines = new List<string>();
            foreach (string fileName in fileNames)
            {
                if (!fileName.Equals(pathToCompare))
                    lines.AddRange(File.ReadAllLines(fileName));
            }

            string[] linesToCompare = File.ReadAllLines(pathToCompare);
            List<string> linesToCompareList = new List<string>();
            linesToCompareList.AddRange(linesToCompare);

            for (int i = 0; i < linesToCompare.Length; i++)
            {
                for (int j = 0; j < lines.Count; j++)
                {
                    if (linesToCompare[i].Equals(lines[j]) && linesToCompareList.Contains(linesToCompare[i]))
                        linesToCompareList.Remove(linesToCompare[i]);
                }
            }

            File.WriteAllLines(pathToCompare + ".bak", linesToCompareList.ToArray());
        }
    }
}
