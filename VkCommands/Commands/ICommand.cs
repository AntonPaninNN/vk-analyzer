using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Data;
using System.Xml;
using VkCommands.Utils;
using VK_COM.Constants;

namespace VkCommands.Commands
{
    public abstract class ICommand
    {
        private string _base = "https://api.vk.com/method/";
        private string commandPath = string.Empty;
        private string commandName = string.Empty;

        public string Base { get { return _base; } }
        public string CommandPath { get { return commandPath; } set { commandPath = value; } }
        public string CommandName { get { return commandName; } set { commandName = value; } }

        public abstract IData performe(Dictionary<string, string> parameters, string token);

        protected XmlDocument getXmlDocument()
        {
            return XmlProcessor.getXml(commandPath);
        }

        protected string getCommandPath(Dictionary<string, string> parameters, string token)
        {
            string commandPath = Base + CommandName + "?";
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                commandPath += pair.Key + "=" + pair.Value + "&";
            }
            commandPath += CommonConstans.TOKEN_PARAM_NAME + token;
            return commandPath;
        }
    }
}
