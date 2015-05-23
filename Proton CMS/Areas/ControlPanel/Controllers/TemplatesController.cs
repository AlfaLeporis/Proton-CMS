using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
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

        [HttpPost]
        public ActionResult AddTemplate(HttpPostedFileBase file)
        {
            if (file.ContentType != "application/zip" && file.ContentType != "application/x-zip-compressed")
            {
                TempData.Add("ErrorMessage", "Template must be in zip file! Try again.");
                return View();
            }

            var fileName = Server.MapPath("/Tmp") + "\\" + DateTime.Now.Ticks.ToString() + ".zip";
            file.SaveAs(fileName);

            try
            {
                templatesService.InstallTemplate(fileName);
            }
            catch
            {
                TempData.Add("ErrorMessage", "Error while installing template.");
                return View();
            }

            TempData.Add("InfoMessage", "Template installed successfully.");
            return View();
        }

        public ActionResult SetCurrentTemplate(int id)
        {
            templatesService.SetCurrentTemplate(id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveTemplate(int id)
        {
            templatesService.RemoveTemplate(id);
            return RedirectToAction("Index");
        }
    }
}