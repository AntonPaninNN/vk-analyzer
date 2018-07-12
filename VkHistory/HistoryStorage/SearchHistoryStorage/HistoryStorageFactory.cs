using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Constants;
using VkHistory.HistoryStorage.SearchHistoryStorage.Impl.FileFormats;
using VK_COM.Enums;

namespace VkHistory.HistoryStorage.SearchHistoryStorage.Impl
{
    public class HistoryStorageFactory
    {
        public static ISearchHistoryStorage getFileHistoryStorage(StorageType sType)
        {
            if (sType == StorageType.File)
            {
                if (CommonConstans.DEFAULT_FILE_FORMAT.Equals("txt"))
                    return new TxtFileHistoryStorage();
                else
                    return null;
            }
            else
                return null;
        }
    }
}
