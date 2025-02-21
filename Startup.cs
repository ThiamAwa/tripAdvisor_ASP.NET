using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcExampleM1GlGroupe2.Startup))]
namespace MvcExampleM1GlGroupe2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
