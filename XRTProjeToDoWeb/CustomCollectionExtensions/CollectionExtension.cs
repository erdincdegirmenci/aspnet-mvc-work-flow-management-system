using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;
using XRTProje.ToDo.DTO.DTOs.UrgencyDTOs;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Business.ValidationRules.FluentValidation;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
               .AddEntityFrameworkStores<TodoContext>();

            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                //cookie baska web sayfalarında paylaşılmasın
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                //document.cookie yazarak cookie bilgisi ulasmasın
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();
            services.AddTransient<IValidator<DutyAddDto>, DutyAddDValidator>();
            services.AddTransient<IValidator<DutyUpdateDto>, DutyUpdateValidator>();
            services.AddTransient<IValidator<AppUserSignUpDto>, AppUserSignUpValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
        }
    }
}
