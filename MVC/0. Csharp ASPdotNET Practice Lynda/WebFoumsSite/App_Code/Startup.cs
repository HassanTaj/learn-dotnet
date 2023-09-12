using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFoumsSite.Startup))]
namespace WebFoumsSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
