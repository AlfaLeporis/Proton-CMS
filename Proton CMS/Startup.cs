using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proton_CMS.Startup))]
namespace Proton_CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
