using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Data;

namespace VkCommands.Commands
{
    public abstract class IUserCommand : ICommand
    {
        public override IData performe(Dictionary<string, string> parameters, string token)
        {
            throw new NotImplementedException();
        }
    }
}
