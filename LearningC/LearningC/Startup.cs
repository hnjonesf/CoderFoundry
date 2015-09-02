using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningC.Startup))]
namespace LearningC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
