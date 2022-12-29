using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IJAP_MVC.Startup))]
namespace IJAP_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
