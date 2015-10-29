using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustBlogging.Startup))]
namespace JustBlogging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
