using System.Reflection;
using FluentValidation;
using LoanWithUs.ApplicationService.Command;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.MediatR.PreRequest;
using MediatR;

namespace LoanWithUs.RestApi.Bootstrap
{
    public static class ConfigureServicesForMediatR
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);
            services.AddMediatR(typeof(CreateApplicantCommand).Assembly);
            services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
            services.AddMediatR(typeof(LoggingHandlerDecorator<>).Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            return services;
        }
    }
}
