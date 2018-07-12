using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VkAuthorization
{
    public abstract class IAuthorization
    {
        protected string token = string.Empty;
        protected string expiresIn = string.Empty;
        protected string initialUser = string.Empty;

        public string Token { get { return token; } set { token = value; } }
        public string ExpiresIn { get { return expiresIn; } set { expiresIn = value; } }
        public string InitialUser { get { return initialUser; } set { initialUser = value; } }

        public abstract bool authorize(Form form);

        public abstract bool deauthorize(Form form);
    }
}
