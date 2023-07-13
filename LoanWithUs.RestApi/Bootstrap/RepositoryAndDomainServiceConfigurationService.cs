using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.DomainService;
using LoanWithUs.Persistense.EF.Repository;
using LoanWithUs.Persistense.EF.UnitOfWork;

namespace LoanWithUs.RestApi.Bootstrap
{
    public static class RepositoryAndDomainServiceConfigurationService
    {
        public static IServiceCollection AddRepositoryAndDomainService(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, LoanWithUsUnitOfWork>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IApplicantReadRepository, ApplicantReadRepository>();
            services.AddScoped<IApplicantDomainService, ApplicantDomainService>();
            services.AddScoped<ISupporterDomainService, SupporterDomainService>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<ISupporterRepository, SupporterRepository>();
            services.AddScoped<ILoanLadderFrameRepository, LoanLadderFrameRepository>();
            services.AddScoped<ILoanLadderFrameDomainService, LoanLadderFrameDomainService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicantLoanRequestDomainService, ApplicantLoanRequestDomainService>();
            services.AddScoped<IApplicantLoanRequestRepository, ApplicantLoanRequestRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));




            return services;
        }
    }
}
