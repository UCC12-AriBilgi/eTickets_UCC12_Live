﻿using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Step02
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
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

            // (18.6)
            // Services configuration
            builder.Services.AddScoped<IActorsService, ActorsService>();



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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
