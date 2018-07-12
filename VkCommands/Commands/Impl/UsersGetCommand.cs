using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VkCommands.Utils;
using VK_COM.Constants;
using VkCommands.Data;
using VkCommands.Data.Impl;

namespace VkCommands.Commands.Impl
{
    class UsersGetCommand : IUserCommand
    {
        private static UsersGetCommand _instance = null;

        private UsersGetCommand() { }

        public static UsersGetCommand getInstance()
        {
            if (_instance == null)
            {
                _instance = new UsersGetCommand();
                _instance.CommandName = "users.get.xml";
            }

            return _instance;
        }

        public override IData performe(Dictionary<string, string> parameters, string token)
        {
            _instance.CommandPath = getCommandPath(parameters, token);

            XmlDocument doc = getXmlDocument();
            User user = new User();
            user.Id = XmlProcessor.getInnerText(doc, XmlConstants.ID_TAG);

            return user;
        }
    }
}
