using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RRHH.Startup))]
namespace RRHH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
