using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExploreCaliDbF.Startup))]
namespace ExploreCaliDbF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
