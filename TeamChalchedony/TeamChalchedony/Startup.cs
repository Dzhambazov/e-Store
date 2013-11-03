using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamChalchedony.Startup))]
namespace TeamChalchedony
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
