using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheatreBookingAppNew.Startup))]
namespace TheatreBookingAppNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
