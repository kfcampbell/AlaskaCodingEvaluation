using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlightSearch.Startup))]
namespace FlightSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
