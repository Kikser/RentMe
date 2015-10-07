using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentMe.Startup))]
namespace RentMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
