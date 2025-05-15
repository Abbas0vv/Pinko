using Microsoft.EntityFrameworkCore;
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
                .AddRoles<PinkoRole>()
                .AddEntityFrameworkStores<PinkoDbContext>();


            builder.Services.AddRazorPages();
            builder.Services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

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
