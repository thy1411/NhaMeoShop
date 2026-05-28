using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NhaMeoShop.Models;
using System.Threading.Tasks;

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

                // DATABASE
                var context = services.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();

                // SEED DATA
                DataSeeder.Seed(context);

                // ROLE MANAGER
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                // USER MANAGER
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                // CREATE ROLES
                string[] roles = {
                    "Admin",
                    "Staff",
                    "Customer"
                };

                foreach (var role in roles)
                {
                    bool exists = await roleManager.RoleExistsAsync(role);

                    if (!exists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // CREATE ADMIN ACCOUNT
                string adminEmail = "admin@nhameo.com";

                string adminPassword = "Admin@123";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, adminPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(
            string[] args) =>

            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}