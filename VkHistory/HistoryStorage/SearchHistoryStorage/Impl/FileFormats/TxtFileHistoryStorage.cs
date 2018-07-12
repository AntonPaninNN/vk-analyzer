using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VkHistory.HistoryData.SearchHistoryData;
using VK_COM.Enums;

namespace VkHistory.HistoryStorage.SearchHistoryStorage.Impl.FileFormats
{
    class TxtFileHistoryStorage : FileHistoryStorage
    {

        protected override void appendFile(string filePath, List<string> lines)
        {
            TextWriter textWriter = null;

            if (File.Exists(filePath))
                textWriter = new StreamWriter(filePath, true);
            else
            {
                File.Create(filePath).Close();
                textWriter = new StreamWriter(filePath);
            }

            appendFile(textWriter, lines);
            textWriter.Close();
        }

        protected TextWriter appendFile(TextWriter textWriter, List<string> lines)
        {
            foreach (string line in lines)
                textWriter.WriteLine(line);

            return textWriter;
        }

        protected override ISearchHistoryData parseUserData(string coreId, List<string> userFiles, SearchType sType)
        {
            List<string> data = new List<string>();
            foreach (string userFile in userFiles)
            {
                data.AddRange(getDataFromFile(userFile));
            }

            ISearchHistoryData searchData = SearchHistoryDataFacory.createSearchHistoryData(sType);
            searchData.SearchIds = data;
            searchData.CoreId = coreId;

            return searchData;
        }

        protected List<string> getDataFromFile(string userFile)
        {
            List<string> data = new List<string>();
            using (StreamReader reader = File.OpenText(userFile))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }

            return data;
        }

    }
}
