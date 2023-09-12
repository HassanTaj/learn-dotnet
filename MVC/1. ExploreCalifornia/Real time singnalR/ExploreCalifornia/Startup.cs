using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExploreCalifornia.Startup))]
namespace ExploreCalifornia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
