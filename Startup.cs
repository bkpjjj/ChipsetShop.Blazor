using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChipsetShop.MVC.Services;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ChipsetShop.MVC.Models;

namespace ChipsetShop.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<ViewRenderService>();

            services.AddTransient<IPasswordValidator<UserModel>,
            CustomPasswordValidator>(serv => new CustomPasswordValidator());

            services.AddTransient<IUserValidator<UserModel>,
            CustomUserValidator>(serv => new CustomUserValidator());

            services.Configure<RouteOptions>(o => o.LowercaseUrls = true);
            services.AddDbContext<DataContext>();
            services.AddControllersWithViews(op => op.EnableEndpointRouting = false)
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson()
                .AddJsonOptions(op => op.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic));
            services.AddIdentity<UserModel, IdentityRole>( o => {o.User.RequireUniqueEmail = true; o.SignIn.RequireConfirmedEmail = true; } )
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
        }
    }
}
