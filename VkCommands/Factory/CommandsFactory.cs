using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Commands;
using VK_COM.Enums;
using VkCommands.Commands.Impl;


namespace VkCommands.Factory
{
    class CommandsFactory
    {
        public static ICommand getCommand(VK_COM.Enums.Commands command)
        {
            if (command == VK_COM.Enums.Commands.AreFriends)
                return FriendsAreFriendsCommand.getInstance();
            else if (command == VK_COM.Enums.Commands.GetFriends)
                return FriendsGetCommand.getInstance();
            else if (command == VK_COM.Enums.Commands.GetUser)
                return UsersGetCommand.getInstance();
            else
                return null;
        }
    }
}
