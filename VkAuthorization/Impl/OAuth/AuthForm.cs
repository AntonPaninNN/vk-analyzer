using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using VkAuthorization.Impl;
using VK_COM.Constants;
using VK_COM.Exceptions;

namespace VkAuthorization
{
    public partial class AuthForm : Form
    {
        private IAuthSubscriber subscriber = null;
        private bool isAuth = true;

        public AuthForm(IAuthSubscriber subscriber, bool isAuth)
        {
            this.subscriber = subscriber;
            this.isAuth = isAuth;
            InitializeComponent();
            _authWebBrowser.ScriptErrorsSuppressed = true;
        }

        private void _authWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string finalUrl = e.Url.ToString();
            if (finalUrl.Contains(OAuthConstants.TOKEN_MARKER))
            {
                string usefulPart = finalUrl.Split(new string[] { OAuthConstants.TOKEN_MARKER }, StringSplitOptions.None)[1];

                if (string.IsNullOrEmpty(usefulPart))
                    throw new AuthException("Empty token");

                string token = getToken(usefulPart);
                if (string.IsNullOrEmpty(token))
                    throw new AuthException("Empty token");

                string expiresIn = getExpiresIn(usefulPart);

                subscriber.onEvent(new AuthEvent(token, expiresIn));
            }
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            if (isAuth)
            {
                _authWebBrowser.Navigate(String.Format(OAuthConstants.OAUTH_URL,
                                        CommonConstans.APP_ID, CommonConstans.APP_RIGHTS));
            }
            else
                _authWebBrowser.Navigate("http://vk.com");
        }

        private string getToken(string url)
        {
            return url.Split(new string[] { OAuthConstants.EXPIRES_IN_MARKER }, StringSplitOptions.None)[0];
        }

        private string getExpiresIn(string url)
        {
            return url.Split(new string[] { OAuthConstants.EXPIRES_IN_MARKER },
                StringSplitOptions.None)[1].Split(new string[] { OAuthConstants.USER_ID_MARKER }, 
                                                                            StringSplitOptions.None)[0];
        }
    }
}
