using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(codingExerciseRework1114.Startup))]
namespace codingExerciseRework1114
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
