using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rentalbase.Startup))]
namespace Rentalbase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
