using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Utils;
using VkCommands.Data;
using VK_COM.Constants;
using System.Xml;
using VkCommands.Data.Impl;

namespace VkCommands.Commands.Impl
{
    class FriendsAreFriendsCommand : IFriendsCommand
    {
        private static FriendsAreFriendsCommand _instance = null;

        private FriendsAreFriendsCommand() { }

        public static FriendsAreFriendsCommand getInstance()
        {
            if (_instance == null)
            {
                _instance = new FriendsAreFriendsCommand();
                _instance.CommandName = "friends.areFriends.xml";
            }

            return _instance;
        }

        public override IData performe(Dictionary<string, string> parameters, string token)
        {
            _instance.CommandPath = getCommandPath(parameters, token);

            XmlDocument doc = getXmlDocument();
            XmlNodeList nList = XmlProcessor.getNodes(doc, XmlConstants.STATUS_TAG);
            string st = string.Empty;
            bool isFriend = false;
            foreach (XmlNode node in nList)
            {
                try
                {
                    st = XmlProcessor.getInnerText(node, XmlConstants.FRIENDS_STATUS_TAG);
                    if (st.Equals("3") || st.Equals("2") || st.Equals("1"))
                    {
                        isFriend = true;
                        break;
                    }
                }
                catch { isFriend = true; break; }
            }

            return new AreFriends(isFriend);
        }
    }
}
