using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SquadClock.Startup))]
namespace SquadClock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
