using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitchBot.Startup))]
namespace TwitchBot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
