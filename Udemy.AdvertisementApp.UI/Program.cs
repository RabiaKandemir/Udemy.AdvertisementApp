using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Udemy.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using Udemy.AdvertisementApp.Business.Helpers;
using Udemy.AdvertisementApp.UI.Mappings.AutoMapper;
using Udemy.AdvertisementApp.UI.Models;
using Udemy.AdvertisementApp.UI.ValidationRules;
namespace Udemy.AdvertisementApp.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDependencies(builder.Configuration);
            builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
  
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(opt =>
      {
          opt.Cookie.Name = "UsemyCookie";

          opt.Cookie.HttpOnly = true;
          opt.Cookie.SameSite = SameSiteMode.Strict;
          opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
          opt.ExpireTimeSpan = TimeSpan.FromDays(20);
          opt.LoginPath = new PathString("/Account/SignIn");
          opt.LogoutPath = new PathString("/Account/LogOut");

          opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
      });
            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            builder.Services.AddSingleton(configuration.CreateMapper());
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
