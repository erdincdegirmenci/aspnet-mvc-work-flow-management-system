using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;
using XRTProje.ToDo.DTO.DTOs.UrgencyDTOs;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.DIContainer;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Business.ValidationRules.FluentValidation;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web;
using YSKProje.ToDo.Web.CustomCollectionExtensions;

namespace XRTProjeToDoWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependencies();

            //services.AddScoped<IDutyService, DutyManager>();
            //services.AddScoped<IReportService, ReportManager>();
            //services.AddScoped<IUrgencyService, UrgencyManager>();
            //services.AddScoped<IAppUserService, AppUserManager>();
            //services.AddScoped<IFileService, FileManager>();
            //services.AddScoped<INotificationService, NotificationManager>();

            //services.AddScoped<IDutyDal, EfDutyRepository>();
            //services.AddScoped<IReportDal, EfReportRepository>();
            //services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            //services.AddScoped<IAppUserDal, EfAppUserRepository>();
            //services.AddScoped<INotificationDal, EfNotificationRepository>();

            services.AddDbContext<TodoContext>();


            services.AddCustomIdentity();
            //services.AddIdentity<AppUser,AppRole>(opt=> {
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequireUppercase = false;
            //    opt.Password.RequiredLength = 1;
            //    opt.Password.RequireLowercase = false;
            //    opt.Password.RequireNonAlphanumeric = false;
            //})
            //    .AddEntityFrameworkStores<TodoContext>();

            //services.AddControllersWithViews();

            //services.ConfigureApplicationCookie(opt =>
            //{
            //    opt.Cookie.Name = "IsTakipCookie";
            //    //cookie baska web sayfalarýnda paylaþýlmasýn
            //    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
            //    //document.cookie yazarak cookie bilgisi ulasmasýn
            //    opt.Cookie.HttpOnly = true;
            //    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            //    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
            //    opt.LoginPath = "/Home/Index";
            //});

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddCustomValidator();


            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //docs.microsoft.com/tr-tr/aspnet/core/fundamentals/error-handling?view=aspnetcore-3.1
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //errorpage
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
