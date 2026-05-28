using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NhaMeoShop.Models;
using System;

namespace NhaMeoShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration
        {
            get;
        }

        // =========================
        // SERVICES
        // =========================
        public void ConfigureServices(
            IServiceCollection services)
        {
            // MVC
            services.AddControllersWithViews();

            // RAZOR PAGES
            services.AddRazorPages();

            // DATABASE
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=NhaMeoShop"));

            // IDENTITY
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                // PASSWORD
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // EMAIL SENDER
            services.AddTransient<IEmailSender, EmailSender>();

            // SESSION
            services.AddSession(options => {options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        // =========================
        // PIPELINE
        // =========================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ERROR
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            // HTTPS
            app.UseHttpsRedirection();

            // STATIC FILE
            app.UseStaticFiles();

            // ROUTING
            app.UseRouting();

            // SESSION
            app.UseSession();

            // LOGIN
            app.UseAuthentication();

            // ROLE
            app.UseAuthorization();

            // ENDPOINT
            app.UseEndpoints(endpoints =>
            {
                // MVC
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

                // IDENTITY
                endpoints.MapRazorPages();
            });
        }
    }
}