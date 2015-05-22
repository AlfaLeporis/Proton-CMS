using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace Proton_CMS.DAL
{
    public class MigrationConfig : DbMigrationsConfiguration<DatabaseContext>
    {
        public MigrationConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
        }
    }
}