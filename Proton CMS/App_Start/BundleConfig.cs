using System.Web;
using System.Web.Optimization;

namespace Proton_CMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/js-controlpanel").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/ControlPanel/jquery.metisMenu.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/ControlPanel/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css-controlpanel").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/ControlPanel/custom.css",
                      "~/Content/ControlPanel/font-awesome.css"));
        }
    }
}
