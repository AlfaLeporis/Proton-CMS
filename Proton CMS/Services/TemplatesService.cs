using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;
using Proton_CMS.Models;
using Proton_CMS.ViewModels;
using Proton_CMS.Services.Interfaces;
using Proton_CMS.DAL;

namespace Proton_CMS.Services
{
    public class TemplatesService : ITemplatesService
    {
        private IDatabaseContext dbContext = null;     
        public int CurrentTemplate { get; set; }

        public TemplatesService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            CurrentTemplate = int.Parse(dbContext.ProtonConfig.First(p => p.Key == "CurrentTemplate").Value);
        }

        public List<TemplateViewModel> GetAllTemplates()
        {
            var viewModels = dbContext.Templates
                .ToList()
                .Select(p => new TemplateViewModel().InjectFrom(p))
                .Cast<TemplateViewModel>()
                .ToList();

            viewModels.First(p => p.ID == CurrentTemplate).IsCurrent = true;
            return viewModels;
        }
    }
}