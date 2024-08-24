using webapplicationday8.Context;
using Microsoft.EntityFrameworkCore;

namespace webapplicationday8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            // step 1 register the classes used for session
            builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
            //step2 register distrubuted memory cache
            builder.Services.AddDistributedMemoryCache();


            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(500);
                options.Cookie.HttpOnly = true; // by default the session key is stored in a cookie in the browser, but the value itself is stored in server side

            });
    builder.Services.AddDbContext<DrugContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MYConn")));

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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
