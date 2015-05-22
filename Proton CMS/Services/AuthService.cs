using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proton_CMS.Services.Interfaces;
using Proton_CMS.DAL;

namespace Proton_CMS.Services
{
    public class AuthService : IAuthService
    {
        private DatabaseContext dbContext = null;

        public AuthService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool LogIn(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}