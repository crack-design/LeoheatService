using System;
using Leoheat.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LeoheatService.Logging;
using Leoheat.DAL.UnitOfWork;
using Leoheat.DAL.Repository;
using Leoheat.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using LeoheatService.Infrastructure;
using LeoheatService.MVCFilters;

namespace LeoheatService
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<LeoheatDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<LeoheatDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Configure Identity


            services.AddAuthentication("cookies")
                .AddCookie("cookies", options => options.LoginPath = "/Account/Login");

            services.AddIdentity<ApplicationUser, IdentityRole>()
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
                options.LoginPath = "/Account/Login";
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<LeoheatObject>, Repository<LeoheatObject>>();
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddHeaderAttribute("CopyrightBy:", "Blah-blah-blah"));
            });

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

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" },
            //        constraints: new { },
            //        dataTokens: new { locale = "uk-UK" });
            //});
        }
    }
}
