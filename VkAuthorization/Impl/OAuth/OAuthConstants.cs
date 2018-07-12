using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkAuthorization.Impl
{
    class OAuthConstants
    {
        public static string TOKEN_MARKER = "access_token=";
        public static string EXPIRES_IN_MARKER = "&expires_in=";
        public static string USER_ID_MARKER = "&user_id=";
        public static string VK_MAIN_PAGE = "http://vk.com";
        public static string OAUTH_URL = "http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token";
    }
}
