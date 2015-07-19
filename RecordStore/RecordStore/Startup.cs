using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecordStore.Startup))]
namespace RecordStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
