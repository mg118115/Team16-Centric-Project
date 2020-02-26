using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team_16_Centric_Project.Startup))]
namespace Team_16_Centric_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
