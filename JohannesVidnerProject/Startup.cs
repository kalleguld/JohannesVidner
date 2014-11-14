using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JohannesVidnerProject.Startup))]
namespace JohannesVidnerProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
