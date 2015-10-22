using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingJavascript.Startup))]
namespace TestingJavascript
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
