﻿using LoanWithUs.Common;
using LoanWithUs.Domain.BasicInfo;
using LoanWithUs.FileService;
using LoanWithUs.Mapper;
using LoanWithUs.Persistense.EF.Repository;

namespace LoanWithUs.RestApi.Bootstrap
{
    public static class FrameworkConfigurationService
    {
        public static IServiceCollection AddFrameworkConfigurationService(this IServiceCollection services, IConfiguration Configuration)
        {
            //           private readonly FileSettings _fileSettings;
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFileService, HardDiskFileService>();
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            var ssoConfigurationSection = Configuration.GetSection("FileSettings");
            var ssoConfig = ssoConfigurationSection.Get<FileSettings>();
            services.AddSingleton(ssoConfig);


            services.AddAutoMapper(new[] { typeof(BasicInfoProfile) });
            return services;

        }
    }
}
