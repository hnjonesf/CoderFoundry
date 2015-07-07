using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechTesting.Startup))]
namespace TechTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
