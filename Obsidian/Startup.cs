using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Obsidian.Startup))]
namespace Obsidian
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
