using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoderFoundry.InsightUserStore.Startup))]
namespace CoderFoundry.InsightUserStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
