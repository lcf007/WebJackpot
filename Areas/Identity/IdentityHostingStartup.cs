using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebJackpot.Areas.Identity.Data;
using WebJackpot.Data;

[assembly: HostingStartup(typeof(WebJackpot.Areas.Identity.IdentityHostingStartup))]
namespace WebJackpot.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<WebJackpotContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("WebJackpotContext")));

            //    services.AddDefaultIdentity<WebJackpotUser>()
            //        .AddEntityFrameworkStores<WebJackpotContext>();
            //});
        }
    }
}