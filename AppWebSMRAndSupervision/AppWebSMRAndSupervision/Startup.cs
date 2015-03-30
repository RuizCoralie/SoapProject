using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppWebSMRAndSupervision.Startup))]
namespace AppWebSMRAndSupervision
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
