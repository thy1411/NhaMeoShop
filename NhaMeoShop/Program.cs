using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace NhaMeoShop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var roleManager =
                    services.GetRequiredService
                    <RoleManager<IdentityRole>>();

                string[] roles =
                {
                    "Admin",
                    "Staff"
                };

                foreach (var role in roles)
                {
                    bool exists =
                        await roleManager
                        .RoleExistsAsync(role);

                    if (!exists)
                    {
                        await roleManager
                            .CreateAsync(
                                new IdentityRole(role));
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(
            string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}