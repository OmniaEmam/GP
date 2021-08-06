using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewGP.Startup))]
namespace NewGP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
