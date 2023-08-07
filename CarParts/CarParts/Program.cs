namespace CarParts.Web
{
    using System.Reflection;
    using Data;
    using Data.Models;
    using Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Services.Data.Interfaces;
    using Services.Mapping;
    using ViewModels.Error;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                                   throw new InvalidOperationException(
                                       "Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //?

            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            //builder.Services.AddScoped<ICarService, CarService>();
            //builder.Services.AddScoped<IPartService, PartService>();
            //builder.Services.AddScoped<IDealerService, DealerService>();
            //builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.RegisterServiceReflection(typeof(ICarService)); //reflection for services

            builder.Services.AddMemoryCache();


            var app = builder.Build();

            app.SeedAdmin();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
                //TODO?: app.SeedAdmin(); (i have it already declared above in this file)
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");

                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Areas",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "Car Details",
                    "/Cars/Details/{id}/{information}",
                    new { controller = "Car", action = "Details" });

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });


            //app.MapControllerRoute(
            //    "default",
            //    "{controller=Home}/{action=Index}/{id?}");


            //app.MapRazorPages();

            app.Run();
        }
    }
}