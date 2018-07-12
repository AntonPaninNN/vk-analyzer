using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Data.Impl;
using VkCommands.Factory;
using VK_COM.Constants;
using VkCommands.Commands;
using VkAuthorization;

namespace VkCommands.Helpers.Impl
{
    public class FriendsHelper : IHelper
    {

        public static Friends getFriends(string coreId)
        {
            ICommand cmd = CommandsFactory.getCommand(VK_COM.Enums.Commands.GetFriends);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(CommonConstans.USER_ID, coreId);
            parameters.Add(CommonConstans.FIELDS, CommonConstans.GET_FRIENDS_REQUEST_DATA);
            return (Friends)cmd.performe(parameters, AuthFactory.getCurrentAuth().Token);
        }

        public static AreFriends areFriends(string coreId, string checkedId)
        {
            ICommand cmd = CommandsFactory.getCommand(VK_COM.Enums.Commands.AreFriends);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(CommonConstans.USER_ID, coreId);
            parameters.Add(CommonConstans.USER_IDS, checkedId);
            return (AreFriends)cmd.performe(parameters, AuthFactory.getCurrentAuth().Token);
        }

    }
}
