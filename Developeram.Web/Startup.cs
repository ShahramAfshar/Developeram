using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Developeram.Web.Startup))]
namespace Developeram.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
