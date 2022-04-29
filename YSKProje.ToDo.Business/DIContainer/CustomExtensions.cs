using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.CustomLogger;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;

namespace YSKProje.ToDo.Business.DIContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDutyService, DutyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IDutyDal, EfDutyRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
