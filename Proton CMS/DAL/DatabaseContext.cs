using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proton_CMS.Models;

namespace Proton_CMS.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ProtonConfigModel> ProtonConfig { get; set; }

        public DatabaseContext() : base("MainConnection")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}