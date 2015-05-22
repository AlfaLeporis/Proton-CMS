using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Proton_CMS.Models;

namespace Proton_CMS.DAL
{
    public interface IDatabaseContext
    {
        IDbSet<ProtonConfig> ProtonConfig { get; set; }

        int SaveChanges();
    }
}
