using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebIndexHotel.Startup))]
namespace WebIndexHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
