using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkCommands.Data.Impl
{
    public class AreFriends : IData
    {
        private bool areFriends = false;

        public bool GetAreFriends { get { return areFriends; } set { areFriends = value; } }

        public AreFriends(bool areFriends)
        {
            this.areFriends = areFriends;
        }
    }
}
