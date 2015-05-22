using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proton_CMS.Services.Interfaces
{
    public interface IAuthService
    {
        bool LogIn(String userName, String password, bool rememberCookie);
        void LogOut();
    }
}
