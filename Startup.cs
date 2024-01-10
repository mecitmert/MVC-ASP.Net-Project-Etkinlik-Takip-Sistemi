using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Etkinlik_Takip_Sistemi.Startup))]
namespace Etkinlik_Takip_Sistemi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
