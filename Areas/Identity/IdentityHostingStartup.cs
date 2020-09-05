using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BeanSceneDipAssT2.Areas.Identity.IdentityHostingStartup))]
namespace BeanSceneDipAssT2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {

        }
    }
}