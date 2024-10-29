using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MvcCodeFirstApproach1.Models;
namespace MvcCodeFirstApproach1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var conn = builder.Configuration.GetConnectionString("Constr");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Categories}/{action=Index}/{id?}");

            app.Run();
        }
        
    }
}
