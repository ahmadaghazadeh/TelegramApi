using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelegramBot.Startup))]
namespace TelegramBot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
