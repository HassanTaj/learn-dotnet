using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContolersAndViews.Startup))]
namespace ContolersAndViews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
