using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nasiha.Startup))]
namespace Nasiha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
