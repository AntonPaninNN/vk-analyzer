using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VkCommands.Data.Impl;
using VK_COM.Constants;
using VkCommands.Data;
using VkCommands.Utils;
using VK_COM.Enums;

namespace VkCommands.Commands.Impl
{
    class FriendsGetCommand : IFriendsCommand
    {
        private static FriendsGetCommand _instance = null;

        private FriendsGetCommand() { }

        public static FriendsGetCommand getInstance()
        {
            if (_instance == null)
            {
                _instance = new FriendsGetCommand();
                _instance.CommandName = "friends.get.xml";
            }

            return _instance;
        }

        public override IData performe(Dictionary<string, string> parameters, string token)
        {
            _instance.CommandPath = getCommandPath(parameters, token);

            XmlDocument doc = getXmlDocument();
            Friends friends = new Friends();
            User user = null;
            List<User> users = new List<User>();
            XmlNodeList nList = XmlProcessor.getNodes(doc, XmlConstants.USER_TAG);
            if (nList != null && nList.Count > 0)
            {
                foreach (XmlNode node in nList)
                {
                    try
                    {
                        user = new User();

                        /* ID */
                        user.Id = XmlProcessor.getInnerText(node, XmlConstants.ID_TAG);

                        /* DOMAIN */
                        user.Domain = "http://vk.com/id" + user.Id;

                        /* FIRST NAME */
                        user.FirstName = XmlProcessor.getInnerText(node, XmlConstants.FIRST_NAME);

                        /* LAST NAME */
                        user.LastName = XmlProcessor.getInnerText(node, XmlConstants.LAST_NAME);

                        /* B-DATE */
                        user.BDate = XmlProcessor.getInnerText(node, XmlConstants.B_DATE);

                        /* STATUS */
                        user.Status = XmlProcessor.getInnerText(node, XmlConstants.STATUS);

                        /* CITY */
                        XmlNode cityNode = XmlProcessor.getNodes(node, XmlConstants.CITY_TAG)[0];
                        if (cityNode == null)
                            user.City = string.Empty;
                        else
                            user.City = XmlProcessor.getInnerText(cityNode, XmlConstants.TITLE_TAG);

                        /* SEX */
                        user.Sex = XmlProcessor.getInnerText(node, XmlConstants.SEX_TAG);
                        if (!string.IsNullOrEmpty(user.Sex))
                            user.Sex = CommonMaps.SexMap[user.Sex];

                        /* HAS MOBILE */
                        user.MobileExists = XmlProcessor.getInnerText(node, XmlConstants.MOBILE);
                        if (!string.IsNullOrEmpty(user.MobileExists) && user.MobileExists.Any(char.IsDigit))
                            user.MobileExists = CommonMaps.HasMobileMap["1"];
                        else
                            user.MobileExists = CommonMaps.HasMobileMap["0"];

                        /* ONLINE */
                        user.IsOnline = XmlProcessor.getInnerText(node, XmlConstants.ONLINE);
                        if (!string.IsNullOrEmpty(user.IsOnline))
                            user.IsOnline = CommonMaps.OnlineMap[user.IsOnline];

                        /* RELATION */
                        user.Family = XmlProcessor.getInnerText(node, XmlConstants.RELATION_TAG);
                        if (!string.IsNullOrEmpty(user.Family))
                            user.Family = CommonMaps.RelationMap[user.Family];

                        /* RELATIVES */
                        XmlNode relativesNode = XmlProcessor.getNodes(node, XmlConstants.RELATIVES_TAG)[0];
                        if (relativesNode == null)
                            user.HasChilds = XmlConstants.FALSE_VALUE_RU;
                        else
                        {
                            /* CHILD */
                            foreach (XmlNode relNode in relativesNode.ChildNodes)
                            {
                                if (XmlProcessor.getInnerText(relNode,
                                    XmlConstants.TYPE_TAG).Equals(XmlConstants.CHILD_TAG))
                                {
                                    user.HasChilds = XmlConstants.TRUE_VALUE_RU;
                                    break;
                                }
                                else
                                {
                                    user.HasChilds = XmlConstants.FALSE_VALUE_RU;
                                }
                            }
                        }
                    }
                    catch { continue; }

                    users.Add(user);
                }
            }
            friends.Users = users;
            return friends;
        }
    }
}

