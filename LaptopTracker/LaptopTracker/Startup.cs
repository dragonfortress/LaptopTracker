using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(LaptopTracker.Startup))]
namespace LaptopTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuthentication(app);
        }
    }
}
