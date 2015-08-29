using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingExercisesC.Startup))]
namespace CodingExercisesC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
