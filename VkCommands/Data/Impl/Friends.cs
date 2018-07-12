using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkCommands.Data.Impl
{
    public class Friends : IData
    {
        private List<User> users = null;

        public List<User> Users { get { return users; } set { users = value; } }
    }
}
