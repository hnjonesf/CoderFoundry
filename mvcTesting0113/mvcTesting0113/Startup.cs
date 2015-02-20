using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcTesting0113.Startup))]
namespace mvcTesting0113
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
