using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital_Appointment.Startup))]
namespace Hospital_Appointment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
