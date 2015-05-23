using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proton_CMS
{
    public static class HtmlHelpers
    {
        public static String SetActiveFlag(this HtmlHelper htmlHelper, String actionName)
        {
            var context = htmlHelper.ViewContext;
            var currentAction = context.RouteData.Values["action"].ToString();

            if (actionName == currentAction)
                return "active";
            else
                return String.Empty;
        }
    }
}