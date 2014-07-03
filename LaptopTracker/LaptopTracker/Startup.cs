using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(LaptopTracker.Startup))]
namespace LaptopTracker
{
    /// <summary>
    /// Startup Class for LaptopTracker Mvc Application
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuthentication(app);
        }
    }
}
