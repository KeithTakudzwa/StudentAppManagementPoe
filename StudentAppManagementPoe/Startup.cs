using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentAppManagementPoe.Startup))]
namespace StudentAppManagementPoe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
