using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2011770131_Trần_Hân_Nhi_BigSchool.Startup))]
namespace _2011770131_Trần_Hân_Nhi_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
