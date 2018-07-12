using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Data.Impl;

namespace VkAnalyzer.State
{
    class GlobalContext
    {
        private GlobalContext() { }

        private static GlobalContext _gContext = null;

        public static GlobalContext getInstance()
        {
            if (_gContext == null)
                _gContext = new GlobalContext();

            return _gContext;
        }

        private ConsoleState state = ConsoleState.Empty;
        public ConsoleState State { get { return state; } set { state = value; } }

        private List<User> currentUsers = null;
        public List<User> CurrentUsers { get { return currentUsers; } set { currentUsers = value; } }

        private List<User> exPeople = new List<User>();
        public List<User> ExcludePeople { get { return exPeople; } set { exPeople = value; } }

        private int coreIdsLenght = 0;
        public int CoreIdsLenght { get { return coreIdsLenght; } set { coreIdsLenght = value; } }

        private int coreIdsCount = 0;
        public int CoreIdsCount { get { return coreIdsCount; } set { coreIdsCount = value; } }
    }
}
