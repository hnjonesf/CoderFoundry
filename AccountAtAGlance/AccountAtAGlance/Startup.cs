using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccountAtAGlance.Startup))]
namespace AccountAtAGlance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
