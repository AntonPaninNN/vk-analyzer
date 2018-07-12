using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace VkAuthorization.Impl
{
    class OAuthAuthorization : IAuthorization, IAuthSubscriber
    {
        private OAuthAuthorization() { }

        private static OAuthAuthorization _instance = null;

        public static OAuthAuthorization getInstance()
        {
            if (_instance == null)
                _instance = new OAuthAuthorization();

            return _instance;
        }

        public override bool authorize(Form form)
        {
            return createForm(true, form);
        }

        #region IAuthSubscriber Members

        public void onEvent(AuthEvent evt)
        {
            this.token = evt.Token;
            this.expiresIn = evt.ExpiresIn;
        }

        #endregion

        public override bool deauthorize(Form form)
        {
            return createForm(false, form);
        }

        private bool createForm(bool isAuth, Form form)
        {
            try
            {
                AuthForm aForm = new AuthForm(this, isAuth);
                aForm.ShowDialog(form);
                return true;
            }
            catch
            { return false; }
        }
    }
}
