using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RapidDeployMVC.Startup))]
namespace RapidDeployMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
