using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Data.Impl;
using System.Reflection;

namespace VkAnalyzer.Helpers
{
    class ChartHelper
    {
        public static SortedDictionary<string, int> prepareChartData(List<User> users,
            string propertyName)
        {
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            string currentValue = string.Empty;
            PropertyInfo[] propertyInfos = typeof(User).GetProperties();

            foreach (User user in users)
            {
                for (int j = 0; j < propertyInfos.Length; j++)
                {
                    if (propertyInfos[j].Name.Equals(propertyName))
                    {
                        currentValue = propertyInfos[j].GetValue(user, null).ToString();

                        if (propertyInfos[j].Name.Equals("BDate"))
                        { 
                            string[] bDateArr = currentValue.Split('.');
                            if (bDateArr.Length != 3)
                                break;

                            currentValue = 
                                (Int32.Parse(DateTime.Now.Year.ToString()) - Int32.Parse(bDateArr[2])).ToString();
                        }

                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            if (dictionary.ContainsKey(currentValue))
                                dictionary[currentValue]++;
                            else
                                dictionary[currentValue] = 1;
                        }
                        break;
                    }
                }
            }
            return dictionary;
        }
    }
}
