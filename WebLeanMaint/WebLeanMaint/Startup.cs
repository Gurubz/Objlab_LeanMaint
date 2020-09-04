using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLeanMaint.Startup))]
namespace WebLeanMaint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
