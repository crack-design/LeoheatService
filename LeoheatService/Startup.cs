using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Leoheat.DAL;
using LeoheatService.ApplicationBuilderExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using LeoheatService.Logging;
using Leoheat.DAL.UnitOfWork;
using Leoheat.DAL.Repository;
using Leoheat.DAL.Entities;
using LeoheatService.Authentication;
using Microsoft.AspNetCore.Identity;

namespace LeoheatService
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<LeoheatDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<LeoheatDbContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            //Configure Identity
            services.AddIdentity<Leoheat.DAL.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LeoheatDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<LeoheatObject>, Repository<LeoheatObject>>();
            services.AddMvc();

            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            loggerFactory.AddLog4Net();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseRequestCulture();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { },
                    dataTokens: new { locale = "uk-UK" });
            });
        }
    }
}
