using System;
using CodeFirstAppWith2Table.Models;
using CodeFirstAppWith2Table.Repository;
using Microsoft.EntityFrameworkCore;


namespace CodeFirstAppWith2Table
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
            //var conn = builder.Configuration.GetConnectionString("ConStr");
           builder.Services.AddDbContext<TutorialDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString(name:"ConStr")));
         
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
