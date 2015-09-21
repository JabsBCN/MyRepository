using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(POC_SignarR.startup))]

namespace POC_SignarR
{
    public class startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
