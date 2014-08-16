using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(versity.Startup))]
namespace versity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
