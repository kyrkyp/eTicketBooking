using eTicketBooking.Data;
using eTicketBooking.Data.Seeders;
using eTicketBooking.Data.Services;
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models.Registry;
using eTickets.Data.Cart;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTicketBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("eTicketDatabase")));

            builder.Services.AddScoped<IActorsService, ActorsService>();
            builder.Services.AddScoped<ICinemasService, CinemasService>();
            builder.Services.AddScoped<IMoviesService, MoviesService>();
            builder.Services.AddScoped<IProducersService, ProducersService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");

            // Seed Data
            AppDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

            app.Run();
        }
    }
}