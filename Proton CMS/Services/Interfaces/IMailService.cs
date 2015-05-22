using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proton_CMS.Services.Interfaces
{
    public interface IMailService
    {
        void SendMail(String title, String content, String fromEMail, String toEMail);
    }
}
