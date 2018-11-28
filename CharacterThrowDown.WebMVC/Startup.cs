using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharacterThrowDown.WebMVC.Startup))]
namespace CharacterThrowDown.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
