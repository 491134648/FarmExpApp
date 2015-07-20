using Microsoft.Owin;
using Owin;

[assembly:OwinStartupAttribute(typeof(FarmExp.WebApp.Startup))]
namespace FarmExp.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            ConfigureAuth(appBuilder);
        }
    }
}