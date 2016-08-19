using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SetPoint.Startup))]
namespace SetPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
