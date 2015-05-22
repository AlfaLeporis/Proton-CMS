using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Proton_CMS.Services.Interfaces;
using Proton_CMS.DAL;

namespace Proton_CMS.Services
{
    public class AuthService : IAuthService
    {
        private IDatabaseContext dbContext = null;

        public AuthService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool LogIn(string userName, string password, bool rememberCookie)
        {
            if (dbContext.ProtonConfig.First(p => p.Key == "AdminName").Value == userName &&
                dbContext.ProtonConfig.First(p => p.Key == "AdminPassword").Value == password)
            {
                FormsAuthentication.SetAuthCookie(userName, rememberCookie);
                return true;
            }

            return false;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}