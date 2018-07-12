using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkAuthorization
{
    public class AuthEvent
    {
        private string token = string.Empty;
        private string expiresIn = string.Empty;

        public string Token { get { return token; } set { token = value; } }
        public string ExpiresIn { get { return expiresIn; } set { expiresIn = value; } }

        public AuthEvent(string token, string expiresIn)
        {
            this.token = token;
            this.expiresIn = expiresIn;
        }

        public AuthEvent()
        { }
    }
}
