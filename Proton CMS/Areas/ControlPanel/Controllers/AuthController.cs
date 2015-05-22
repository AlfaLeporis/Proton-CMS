using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proton_CMS.Services.Interfaces;

namespace Proton_CMS.Areas.ControlPanel.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService authService = null;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // GET: ControlPanel/Auth
        public ActionResult Index()
        {
            return View();
        }
    }
}