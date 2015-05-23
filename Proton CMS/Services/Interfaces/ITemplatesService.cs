using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proton_CMS.ViewModels;

namespace Proton_CMS.Services.Interfaces
{
    public interface ITemplatesService
    {
        int CurrentTemplate { get; set; }

        List<TemplateViewModel> GetAllTemplates();
        void InstallTemplate(String fileName);
    }
}