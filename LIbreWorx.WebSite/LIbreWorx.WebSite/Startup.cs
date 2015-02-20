using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LIbreWorx.WebSite.Startup))]
namespace LIbreWorx.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
