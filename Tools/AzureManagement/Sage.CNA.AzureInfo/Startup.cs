using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sage.CNA.AzureInfo.Startup))]
namespace Sage.CNA.AzureInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
