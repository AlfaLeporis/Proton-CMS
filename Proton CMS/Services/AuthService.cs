using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.IO;
using Proton_CMS.Services.Interfaces;
using Proton_CMS.DAL;

namespace Proton_CMS.Services
{
    public class AuthService : IAuthService
    {
        private IDatabaseContext dbContext = null;
        private IMailService mailService = null;

        public AuthService(IDatabaseContext dbContext, IMailService mailService)
        {
            this.dbContext = dbContext;
            this.mailService = mailService;
        }

        public bool LogIn(string userName, string password, bool rememberCookie)
        {
            if (dbContext.ProtonConfig.First(p => p.Key == "AdminName").Value == userName &&
                dbContext.ProtonConfig.First(p => p.Key == "AdminPassword").Value == password)
            {
                FormsAuthentication.SetAuthCookie(userName, rememberCookie);
                return true;
            }

            return false;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        public void RemindPassword()
        {
            var templatePatch = HttpContext.Current.Server.MapPath("/MailTemplates/RemindPassword.txt");
            var mailTemplateFile = new StreamReader(templatePatch);
            var templateContent = mailTemplateFile.ReadToEnd();
            mailTemplateFile.Close();

            var userName = dbContext.ProtonConfig.First(p => p.Key == "AdminName").Value;
            var password = dbContext.ProtonConfig.First(p => p.Key == "AdminPassword").Value;
            var emailFrom = dbContext.ProtonConfig.First(p => p.Key == "SmtpMailFrom").Value;
            var emailTo = dbContext.ProtonConfig.First(p => p.Key == "AdminEMail").Value;

            templateContent = templateContent.Replace("{userName}", userName);
            templateContent = templateContent.Replace("{password}", password);

            mailService.SendMail("Proton CMS Message", templateContent, emailFrom, emailTo);
        }
    }
}