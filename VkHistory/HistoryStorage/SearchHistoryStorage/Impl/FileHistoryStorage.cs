using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Constants;
using System.IO;
using VK_COM.Enums;
using VkHistory.HistoryData.SearchHistoryData;
using System.Reflection;
using VK_COM.Exceptions;

namespace VkHistory.HistoryStorage.SearchHistoryStorage.Impl
{
    abstract class FileHistoryStorage : ISearchHistoryStorage
    { 

        #region ISearchHistoryStorage Members

        public void saveSearchHistoryData(ISearchHistoryData hData)
        {
            if (hData == null)
                throw new ArgumetsException("hData is null");

            if (string.IsNullOrEmpty(hData.CoreId))
                throw new ArgumetsException("hData.CoreId is null or empty");

            if (hData.SearchTimestamp == null)
                throw new ArgumetsException("hData.SearchTimestamp is null");

            if (hData.SearchIds == null)
                throw new ArgumetsException("hData.SearchIds is null");

            if (hData.SearchIds.Count <= 0)
                throw new ArgumetsException("hData.SearchIds is empty");

            createDirectory(CommonConstans.DEFAULT_FILE_STORAGE_PATH);
            string userDir = getUserDirectory(hData.CoreId);
            createDirectory(userDir);
            string fileName = getUserFile(hData.SearchTimestamp, hData.SearchDataType, hData.CoreId);
            appendFile(getFullUserFilePath(userDir, fileName), hData.SearchIds);
        }

        public ISearchHistoryData loadSearchHistoryData(string coreId, SearchType sType)
        {
            if (string.IsNullOrEmpty(coreId))
                throw new ArgumetsException("coreId is null or empty");

            return parseUserData(coreId, getUserFiles(coreId), sType);
        }

        #endregion

        protected void createDirectory(string dirName)
        {
            bool exists = Directory.Exists(dirName);

            if (!exists)
                Directory.CreateDirectory(dirName);
        }

        protected abstract void appendFile(string filePath, List<string> lines);

        protected abstract ISearchHistoryData parseUserData(string coreId, List<string> userFiles, SearchType sType); 

        protected string getUserDirectory(string coreId)
        {
            return string.Format("{0}\\{1}", CommonConstans.DEFAULT_FILE_STORAGE_PATH, coreId);
        }

        protected string getUserFile(DateTime searchTimestamp, SearchType sType, string coreId)
        {
            return string.Format("{0}_{1}_{2}.{3}",
                searchTimestamp.ToString(CommonConstans.DEFAULT_DATA_FORMAT),
                sType.ToString(), coreId, CommonConstans.DEFAULT_FILE_FORMAT);
        }
        protected string getFullUserFilePath(string userDir, string userFile)
        {
            return string.Format("{0}\\{1}", userDir, userFile);
        }

        protected List<string> getUserFiles(string coreId)
        {
            List<string> userFiles = new List<string>();
            string userDir = getUserDirectory(coreId);
            DirectoryInfo dirInfo = new DirectoryInfo(userDir);

            foreach (FileInfo userFile in dirInfo.GetFiles("*." + CommonConstans.DEFAULT_FILE_FORMAT))
            {
                userFiles.Add(userFile.FullName);
            }

            return userFiles;
        }

    }
}
