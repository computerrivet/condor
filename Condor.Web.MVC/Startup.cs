using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Condor.Web.MVC.Startup))]
namespace Condor.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
