using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Application_Base_MySQL.Startup))]
namespace Application_Base_MySQL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
