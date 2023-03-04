using FluentValidation;
using LoanWithUs.ApplicationService.Contract;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class SecurUserDataBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly UserDataSecurityDate _userDataSecurity;

    

        public SecurUserDataBehaviour(IEnumerable<IValidator<TRequest>> validators, UserDataSecurityDate userDataSecurity)
        {
            _validators = validators;
            _userDataSecurity = userDataSecurity;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
          
            if(request is UserDataSecurityDate)
            {
                request.GetType().GetProperty("UserAgent").SetValue(request, _userDataSecurity.UserAgent);
                request.GetType().GetProperty("IP").SetValue(request, _userDataSecurity.IP);
            }

            return await next();
        }
    }
}
