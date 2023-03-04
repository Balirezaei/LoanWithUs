using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Domain;
using LoanWithUs.DomainService;
using LoanWithUs.Encryption;
using LoanWithUs.Persistense.EF.Repository;
using LoanWithUs.Persistense.EF.UnitOfWork;

namespace LoanWithUs.RestApi.Bootstrap
{
    public static class RepositoryConfigurationService
    {
        public static IServiceCollection AddRepositoryConfigurationService(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, LoanWithUsUnitOfWork>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IApplicantReadRepository, ApplicantReadRepository>();
            services.AddScoped<IApplicantDomainService, ApplicantDomainService>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<ISupporterRepository, SupporterRepository>();
            
            return services;
        }
    }
}
