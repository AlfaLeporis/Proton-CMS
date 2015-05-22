using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.IO;
using Proton_CMS.DAL;
using Proton_CMS.Services.Interfaces;

namespace Proton_CMS.Services
{
    public class MailService : IMailService
    {
        private IDatabaseContext dbContext = null;

        public MailService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SendMail(string title, string content, string fromEMail, string toEMail)
        {
            var host = dbContext.ProtonConfig.First(p => p.Key == "SmtpHost").Value;
            var port = int.Parse(dbContext.ProtonConfig.First(p => p.Key == "SmtpPort").Value);
            var useSSL = bool.Parse(dbContext.ProtonConfig.First(p => p.Key == "SmtpUseSSL").Value);

            var mail = new MailMessage(fromEMail, toEMail, title, content);
            var smtp = new SmtpClient(host, port);
            throw new NotImplementedException();
        }
    }
}