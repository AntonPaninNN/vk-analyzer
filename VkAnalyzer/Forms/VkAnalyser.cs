using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VkAnalyzer.Events;
using VkAnalyzer.Events.Events;
using VkAnalyzer.Forms;
using VkSearch.Helpers.Impl;
using VkSearch.Events;
using VkAnalyzer.Presenters;
using VkAnalyzer.Factories;
using ConsoleMock;
using System.Threading;
using VkAuthorization;
using VK_COM.Enums;
using VkCommands.Data.Impl;
using System.Windows.Forms.DataVisualization.Charting;
using VkAnalyzer.Charts.Impl;
using VkAnalyzer.Helpers;
using VkAnalyzer.State;
using VkAnalyzer.Enums;
using VkAnalyzer.Charts;
using VkAnalyzer.Fake;
using System.IO;
using VkHistory.DataLoader;
using VkHistory.DataLoader.Impl;
using VkHistory.HistoryData.SearchHistoryData;

namespace VkAnalyzer
{
    public partial class VkAnalyser : Form, ISubscriber, ISearchSubscriber
    {
        private Dictionary<string, string> _parameters = null;
        private IConsolePresenter _console = null;
        //private List<User> _currentUsers = null;

        public VkAnalyser()
        {
            InitializeComponent();
            //chartTest();
            _cityDiag.Visible = false;
            _sexDiag.Visible = false;
            _peopleIdRb.Checked = true;
            _groupIdRb.Checked = false;
            _console = ConsoleFactory.getConsolePresenter(_consoleTb, this, ConsoleType.TextBox);
        }

        #region ISubscriber Members

        public void onEvent(IEvent evt)
        {
            _parameters = evt.Parameters;
        }

        #endregion

        private void _filtersBtn_Click(object sender, EventArgs e)
        {
            Filters filters = new Filters(this);
            filters.ShowDialog(this);
        }

        private void _startSearchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_coreIdTb.Text))
            {
                MessageBox.Show("Заполните поле \"Корневой ID\"", "Ошибка");
                return;
            }

            int depth = -1;
            if (!Int32.TryParse(_depthCb.Text, out depth))
            {
                MessageBox.Show("Введено некорректное значение в поле \"Глубина поиска\"", "Ошибка");
                return;
            }

            if (depth < 1 || depth > 5)
            {
                MessageBox.Show("Введено некорректное значение в поле \"Глубина поиска\"", "Ошибка");
                return;
            }

            /********************/
            /******* MOCK *******/
            /********************/

            if (string.IsNullOrEmpty(_areFriendsCb.Text))
            {
                MessageBox.Show("Введено некорректное значение в поле \"Проверка на \"друзья\"\"", "Ошибка");
                return;
            }

            bool checkFriends = false;
            if (_areFriendsCb.Text.Equals("Да"))
                checkFriends = true;

            ThreadPool.QueueUserWorkItem(new WaitCallback((s) =>
            {
                GlobalContext.getInstance().ExcludePeople = getExcludePeople();
                GlobalContext.getInstance().CoreIdsLenght = _coreIdTb.Lines.Length;
                GlobalContext.getInstance().CoreIdsCount = 0;

                foreach (string coreId in _coreIdTb.Lines)
                {
                    GlobalContext.getInstance().CoreIdsCount += GlobalContext.getInstance().CoreIdsCount;
                    GlobalContext.getInstance().CurrentUsers =
                        SearchHelper.performeTreesSearchForPeople(coreId,
                        depth, _parameters, this, checkFriends);
                }

                foreach (User user in GlobalContext.getInstance().ExcludePeople)
                {
                    if (GlobalContext.getInstance().CurrentUsers.Contains(user))
                        GlobalContext.getInstance().CurrentUsers.Remove(user);
                }

            }));

            /********************/
            /******* MOCK *******/
            /********************/
        }

        #region ISearchSubscriber Members

        private List<User> getExcludePeople()
        {
            List<User> users = new List<User>();
            users.AddRange(getExcludePeopleFromId());
            users.AddRange(getExcludePeopleFromFolder());
            return users;
        }

        private List<User> getExcludePeopleFromFolder()
        {
            if (string.IsNullOrEmpty(_excludePathTb.Text))
                return new List<User>();

            IDataLoader loader = new AnyFileTypeLoader();
            ISearchHistoryData data = loader.loadData(_excludePathTb.Text);
            User user = null;
            List<User> exUsers = new List<User>();

            foreach (string id in data.SearchIds)
            {
                if (id.Contains("id"))
                {
                    user = new User();
                    user.Id = id.Split(new string[] { "id" }, StringSplitOptions.None)[1];
                    exUsers.Add(user);
                }
            }

            return exUsers;
        }

        private List<User> getExcludePeopleFromId()
        {
            string[] exIds = _excludePeopleTb.Lines;
            if (exIds == null || exIds.Length <= 0)
                return new List<User>();
            
            List<User> exPeople = null;
            List<User> allExPeople = new List<User>();
            foreach (string exId in exIds)
            {
                exPeople = SearchHelper.performeTreesSearchForPeople(exId,
                    0, new Dictionary<string, string>(), FakeSearchSubscriber.getInstance(), false);

                if (exPeople != null && exPeople.Count > 0)
                {
                    allExPeople.AddRange(exPeople);
                }
            }

            return allExPeople;
        }

        public void onItemFoundEvent(ISearchEvent evt)
        {
            string id = evt.getItem();
            foreach (User user in GlobalContext.getInstance().ExcludePeople)
            {
                if (user.Id.Equals(id))
                    return;
            }

            id = "http://vk.com/id" + id;
            string line = "<br><br><a href=\"" + id + "\">" + id + "</a>";
            
            if (!_console.containsItem(line))
                _console.appendLineToConsole(line);

            _countLab.Text = _consoleTb.Lines.Length.ToString();
        }

        public void onSearchStarted()
        {
            GlobalContext.getInstance().State = ConsoleState.InProgress;
            ChartGlobalMap.getInstance().deinitCurrentCharts();
            GlobalContext.getInstance().CurrentUsers = null;
            this.Invoke((MethodInvoker)delegate()
            {
                _stopSearchBtn.Enabled = true;
                _startSearchBtn.Enabled = false;

                _clearConsoleBtn.Enabled = false;
                _saveToFileBtn.Enabled = false;
                _loadFromFileBtn.Enabled = false;
                _loadFromHistoryBtn.Enabled = false;
                _loginBtn.Enabled = false;
                _filtersBtn.Enabled = false;
            });
        }

        public void onSearchFinished()
        {
            if (GlobalContext.getInstance().CoreIdsLenght != GlobalContext.getInstance().CoreIdsCount)
                return;

            GlobalContext.getInstance().State = ConsoleState.NotEmpty;
            ChartGlobalMap.getInstance().initCurrentCharts();
            this.Invoke((MethodInvoker)delegate()
            {
                _stopSearchBtn.Enabled = false;
                _startSearchBtn.Enabled = true;

                _clearConsoleBtn.Enabled = true;
                _saveToFileBtn.Enabled = true;
                _loadFromFileBtn.Enabled = true;
                _loadFromHistoryBtn.Enabled = true;
                _loginBtn.Enabled = true;
                _filtersBtn.Enabled = true;
            });
        }

        #endregion

        private void _stopSearchBtn_Click(object sender, EventArgs e)
        {
            /********************/
            /******* MOCK *******/
            /********************/

            //ConsoleDataGenerator.stopSearch();

            /********************/
            /******* MOCK *******/
            /********************/

            SearchHelper.stopSearch();
        }

        private void _clearConsoleBtn_Click(object sender, EventArgs e)
        {
            _console.clearConsole();
            _countLab.Text = "0";
            GlobalContext.getInstance().State = ConsoleState.Empty;
            GlobalContext.getInstance().CurrentUsers = null;
        }

        private void _loginBtn_Click(object sender, EventArgs e)
        {
            AuthFactory.getAuth(AuthType.OAuth).authorize(this);
        }

        private void _consoleTb_TextChanged(object sender, EventArgs e)
        {
            _countLab.Text = _consoleTb.Lines.Length.ToString();
        }

        private void _showDiagramBtn_Click(object sender, EventArgs e)
        {
            string selected = _diagramCb.SelectedItem.ToString();
            
            if (string.IsNullOrEmpty(selected))
                return;

            if (!VkAnalyzer.Enums.CommonMaps.UserParametersMap.ContainsKey(selected))
                return;

            string value = VkAnalyzer.Enums.CommonMaps.UserParametersMap[selected];

            if (!ChartGlobalMap.getInstance().CurrentCharts.ContainsKey(value))
            {
                Chart chart = getChart(value);
                ChartGlobalMap.getInstance().CurrentCharts.Add(value, chart);
                ChartBuilderFactory.getChartBuilder(value, chart);
            }

            resetChartVisibility();
            ChartGlobalMap.getInstance().CurrentCharts[value].Visible = true;
        }

        private Chart getChart(string param)
        {
            if (param.Equals("City"))
                return _cityDiag;
            else if (param.Equals("Sex"))
                return _sexDiag;
            else if (param.Equals("Family"))
                return _familyDiag;
            else if (param.Equals("HasChilds"))
                return _kidsDiag;
            else if (param.Equals("MobileExists"))
                return _mobileDiag;
            else if (param.Equals("IsOnline"))
                return _onlineDiag;
            else if (param.Equals("BDate"))
                return _bdateDiag;
            else
                return null;
        }

        private void resetChartVisibility()
        {
            _cityDiag.Visible = false;
            _sexDiag.Visible = false;
            _familyDiag.Visible = false;
            _kidsDiag.Visible = false;
            _mobileDiag.Visible = false;
            _onlineDiag.Visible = false;
            _bdateDiag.Visible = false;
        }

        private void _saveDiagramBtn_Click(object sender, EventArgs e)
        {
            // this.chart1.SaveImage("C:\\mycode\\mychart.png", ChartImageFormat.Png);
        }

        private void _excludePathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _excludePathTb.Text = fbd.SelectedPath;
                }
                catch
                {
                    MessageBox.Show("Ошибка выбора каталога",
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
