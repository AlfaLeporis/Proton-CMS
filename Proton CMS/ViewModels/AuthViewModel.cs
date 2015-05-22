using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proton_CMS.ViewModels
{
    public class AuthViewModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }
}