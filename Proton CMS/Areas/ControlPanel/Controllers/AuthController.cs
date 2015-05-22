using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proton_CMS.Services.Interfaces;
using Proton_CMS.ViewModels;

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

        [HttpPost]
        public ActionResult LogIn(AuthViewModel viewModel)
        {
            var result = authService.LogIn(viewModel.UserName, viewModel.Password);
            if(result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}