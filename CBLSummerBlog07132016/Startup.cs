using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CBLSummerBlog07132016.Startup))]
namespace CBLSummerBlog07132016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
