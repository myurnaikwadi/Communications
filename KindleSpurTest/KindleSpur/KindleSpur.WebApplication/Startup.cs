using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KindleSpur.WebApplication.Startup))]
namespace KindleSpur.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
