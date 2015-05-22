using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Proton_CMS.DAL;

namespace Proton_CMS.App_Start
{
    public class Bootstrap
    {
        public void Init()
        {
            InitFramework();
            InitDatabase();
        }

        private void InitFramework()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, MigrationConfig>());
           
            //Test if connection works good
            var dbTest = new DatabaseContext();
            dbTest.Database.Initialize(true);
            dbTest.Dispose();
        }
    }
}