using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsingControlersAndViews.Startup))]
namespace UsingControlersAndViews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
