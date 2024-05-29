using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Step04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DbContext configuration
            //(6)
            //builder.Services.AddDbContext<AppDbContext>();
            // (10)
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            // (18.6)
            // Services configuration
            // Servisleri register etmek gerekiyor. Burada bu işlem yapılıyor.
            builder.Services.AddScoped<IActorsService, ActorsService>();
            builder.Services.AddScoped<IProducersService, ProducerService>();
            builder.Services.AddScoped<ICinemasService, CinemasSevice>();
            builder.Services.AddScoped<IMoviesService, MoviesService>(); // 40

            // 50..Authentication/Authorization servisleri
            // Microsoft documentation
            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession(); //  68
            builder.Services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });



            builder.Services.AddControllersWithViews();

            //
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

            // 50.
            app.UseSession(); // 68
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");

            AppDbInitializer.Seed(app);

            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

            app.Run();
        }
    }
}
