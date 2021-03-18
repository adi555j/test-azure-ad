using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using test_azure_ad.Areas.Identity.Data;
using test_azure_ad.Data;

[assembly: HostingStartup(typeof(test_azure_ad.Areas.Identity.IdentityHostingStartup))]
namespace test_azure_ad.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<test_azure_adContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("test_azure_adContextConnection")));

                services.AddIdentityCore<test_azure_adUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<test_azure_adContext>();

                services.AddScoped<UserManager<test_azure_adUser>>();
            });
        }
    }
}