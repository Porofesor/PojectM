using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Configure
{
    public class ConfigureServices
    {
        public ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<UserAccount>
        }
    }
}
