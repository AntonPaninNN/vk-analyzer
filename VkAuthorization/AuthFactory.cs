using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;
using VkAuthorization.Impl;

namespace VkAuthorization
{
    public class AuthFactory
    {
        private static IAuthorization currentAuth = null;

        public static IAuthorization getCurrentAuth()
        {
            return currentAuth;
        }

        public static IAuthorization getAuth(AuthType aType)
        {
            if (aType == AuthType.OAuth)
            {
                currentAuth = OAuthAuthorization.getInstance();
                return currentAuth;
            }
            else
                return null;
        }
    }
}
