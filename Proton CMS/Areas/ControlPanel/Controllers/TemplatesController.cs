using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proton_CMS.Services.Interfaces;

namespace Proton_CMS.Areas.ControlPanel.Controllers
{
    public class TemplatesController : Controller
    {
        ITemplatesService templatesService = null;

        public TemplatesController(ITemplatesService templatesService)
        {
            this.templatesService = templatesService;
        }

        // GET: ControlPanel/Templates
        public ActionResult Index()
        {
            var templates = templatesService.GetAllTemplates();
            return View(templates);
        }

        [HttpGet]
        public ActionResult AddTemplate()
        {
            return View();
        }
    }
}