using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(web3.Areas.Identity.IdentityHostingStartup))]
namespace web3.Areas.Identity
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