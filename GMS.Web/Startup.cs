using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMS.Web.Startup))]
namespace GMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
