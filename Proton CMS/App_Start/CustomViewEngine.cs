using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proton_CMS.App_Start
{
    public class CustomViewEngine : RazorViewEngine
    {
        public String TemplateName { get; set; }

        public CustomViewEngine()
        {
            TemplateName = "Default";

            ViewLocationFormats = new string[]
            {
                "~/Templates/" + TemplateName + "/{1}/{0}.cshtml",
                "~/Templates/" + TemplateName + "/Shared/{0}.cshtml",
            };

            PartialViewLocationFormats = new string[]
            {
                "~/Templates/" + TemplateName + "/{1}/{0}.cshtml",
                "~/Templates/" + TemplateName + "/Shared/{0}.cshtml",
            };
        }
    }
}