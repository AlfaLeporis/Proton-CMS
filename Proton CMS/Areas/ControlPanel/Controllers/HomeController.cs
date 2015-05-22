using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proton_CMS.Areas.ControlPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: ControlPanel/Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}