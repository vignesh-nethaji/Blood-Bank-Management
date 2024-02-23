using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloodBank.Management.Web.Startup))]
namespace BloodBank.Management.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
