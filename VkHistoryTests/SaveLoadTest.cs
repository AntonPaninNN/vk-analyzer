using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkHistory.HistoryStorage.SearchHistoryStorage;
using VkHistory.HistoryStorage.SearchHistoryStorage.Impl;
using VK_COM.Enums;
using VkHistory.HistoryData.SearchHistoryData;
using VkHistory.DataLoader;
using VkHistory.DataLoader.Impl;

namespace VkHistoryTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SaveLoadTest
    {
        public SaveLoadTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void LoadLineData()
        {
            IDataLoader loader = new AnyFileTypeLoader();
            ISearchHistoryData l_Data = loader.loadData(@"C:\FREEDOM\VK\VK\bin\Debug");
            Assert.IsNotNull(l_Data);
            Assert.IsNotNull(l_Data.SearchIds);
            Assert.IsFalse(l_Data.SearchIds.Count == 0);
            foreach (string line in l_Data.SearchIds)
            {
                Assert.IsTrue(line.Contains("vk.com"));
            }
        }

        [TestMethod]
        public void SaveLoadData()
        {
            ISearchHistoryStorage storage = HistoryStorageFactory.getFileHistoryStorage(StorageType.File);

            /**********************/
            /*      FIRST SET     */
            /**********************/

            ISearchHistoryData searchData = SearchHistoryDataFacory.createSearchHistoryData(SearchType.People);
            DateTime timeStamp = DateTime.Now;

            /* Generate random search IDs */
            Random rnd = new Random();
            List<string> searchIds = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                searchIds.Add(rnd.Next(2000, 3000).ToString());
            }

            string coreId = "55555";
            searchData.CoreId = coreId;
            searchData.SearchIds = searchIds;
            searchData.SearchTimestamp = timeStamp;

            storage.saveSearchHistoryData(searchData);

            /**********************/
            /*      SECOND SET    */
            /**********************/

            ISearchHistoryData s_searchData = SearchHistoryDataFacory.createSearchHistoryData(SearchType.People);
            DateTime s_timeStamp = DateTime.Now;

            /* Generate random search IDs */
            Random s_rnd = new Random();
            List<string> s_searchIds = new List<string>();
            for (int s_i = 0; s_i < 533; s_i++)
            {
                s_searchIds.Add(s_rnd.Next(2000, 3000).ToString());
            }

            string s_coreId = "666666";
            s_searchData.CoreId = s_coreId;
            s_searchData.SearchIds = s_searchIds;
            s_searchData.SearchTimestamp = s_timeStamp;

            storage.saveSearchHistoryData(s_searchData);

            /**********************/
            /*      THIRD SET    */
            /**********************/

            ISearchHistoryData t_searchData = SearchHistoryDataFacory.createSearchHistoryData(SearchType.People);
            DateTime t_timeStamp = new DateTime(2012, 01, 01);

            /* Generate random search IDs */
            Random t_rnd = new Random();
            List<string> t_searchIds = new List<string>();
            for (int t_i = 0; t_i < 781; t_i++)
            {
                t_searchIds.Add(t_rnd.Next(2000, 3000).ToString());
            }

            string t_coreId = "666666";
            t_searchData.CoreId = t_coreId;
            t_searchData.SearchIds = t_searchIds;
            t_searchData.SearchTimestamp = t_timeStamp;

            storage.saveSearchHistoryData(t_searchData);

            /**********************/
            /*    FIRST RESULT    */
            /**********************/

            ISearchHistoryData loadedData = storage.loadSearchHistoryData(coreId, SearchType.People);

            Assert.AreEqual(loadedData.CoreId, coreId);
            Assert.AreEqual(loadedData.SearchDataType, SearchType.People);
            Assert.AreEqual(loadedData.SearchIds.Count, searchIds.Count);
            for (int f_r = 0; f_r < searchIds.Count; f_r++)
            {
                Assert.AreEqual(loadedData.SearchIds[f_r], searchIds[f_r]);
            }

            /**********************/
            /*    SECOND RESULT   */
            /**********************/

            ISearchHistoryData s_loadedData = storage.loadSearchHistoryData(s_coreId, SearchType.People);

            Assert.AreEqual(s_loadedData.CoreId, s_coreId);
            Assert.AreEqual(s_loadedData.SearchDataType, SearchType.People);
            Assert.AreEqual(s_loadedData.SearchIds.Count, (s_searchIds.Count + t_searchIds.Count));  
        }

    }
}
