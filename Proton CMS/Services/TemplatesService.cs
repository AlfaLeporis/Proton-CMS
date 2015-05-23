using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Xml;
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

        public void InstallTemplate(String fileName)
        {
            var dest = HttpContext.Current.Server.MapPath("/Templates/");
            var filesBeforeSave = Directory.GetDirectories(dest).ToList();

            ZipFile.ExtractToDirectory(fileName, dest);
            var filesAfterSave = Directory.GetDirectories(dest).ToList();

            foreach(String dir in filesBeforeSave)
            {
                filesAfterSave.Remove(dir);
            }

            var templatePath = filesAfterSave[0];
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(templatePath + "/Installation.xml");

            var templateModel = new TemplateModel();
            templateModel.Name = xmlDoc.GetElementsByTagName("Name")[0].InnerText;
            templateModel.Version = xmlDoc.GetElementsByTagName("Version")[0].InnerText;
            templateModel.Author = xmlDoc.GetElementsByTagName("Author")[0].InnerText;
            templateModel.Description = xmlDoc.GetElementsByTagName("Description")[0].InnerText;
            templateModel.FolderName = templatePath.Split('\\').Last();

            dbContext.Templates.Add(templateModel);
            dbContext.SaveChanges();

            File.Delete(fileName);
        }

        public void SetCurrentTemplate(int id)
        {
            if (!dbContext.Templates.Any(p => p.ID == id))
                throw new Exception("Template id not found");

            dbContext.ProtonConfig.First(p => p.Key == "CurrentTemplate").Value = id.ToString();
            CurrentTemplate = id;

            dbContext.SaveChanges();
        }

        public void RemoveTemplate(int id)
        {
            if (!dbContext.Templates.Any(p => p.ID == id))
                throw new Exception("Template id not found");

            var templateFolder = dbContext.Templates.First(p => p.ID == id).FolderName;
            var dest = HttpContext.Current.Server.MapPath("/Templates/") + "/" + templateFolder;
            Directory.Delete(dest, true);

            dbContext.Templates.Remove(dbContext.Templates.First(p => p.ID == id));
            dbContext.SaveChanges();
        }
    }
}