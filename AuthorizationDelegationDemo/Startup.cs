using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace AuthorizationDelegationDemo
{
    public partial class Startup
    {
        public static TokenCache AccessTokenCache = new TokenCache();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
