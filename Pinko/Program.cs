using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pinko.Database;
using Pinko.Database.Interfaces;
using Pinko.Database.Models.Account;
using Pinko.Database.Repositories;

namespace Pinko
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<PinkoDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<PinkoUser, PinkoRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PinkoDbContext>();


            builder.Services.AddRazorPages();
            builder.Services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            builder.Services.Configure<IdentityOptions>(opt =>
            {
                // Password settings.
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = true;

                // Lockout settings.
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            });

            builder.Services.AddScoped<EmployeeRepository>();

            var app = builder.Build();

            app.UseStaticFiles();


            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
