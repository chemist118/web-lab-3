using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Lab3.Areas.Identity.IdentityHostingStartup))]
namespace Lab3.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}