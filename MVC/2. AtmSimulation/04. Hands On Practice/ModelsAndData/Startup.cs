using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATMEntryPoint.Startup))]
namespace ATMEntryPoint {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
