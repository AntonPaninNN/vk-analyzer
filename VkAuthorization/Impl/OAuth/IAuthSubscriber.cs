using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkAuthorization
{
    public interface IAuthSubscriber
    {
        void onEvent(AuthEvent evt);
    }
}
