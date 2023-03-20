using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Administrator
{
    public class ValidateUserActivationCodeQueryHandler : IRequestHandler<ValidateAdministratorOTPQuery, AdministratorOTPValidationResult>
    {
        private readonly IAdministratorRepository _administratorRepository;

        public ValidateUserActivationCodeQueryHandler(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        public async Task<AdministratorOTPValidationResult> Handle(ValidateAdministratorOTPQuery request, CancellationToken cancellationToken)
        {
            var result = await _administratorRepository.CheckOtpCode(request.key, request.code, request.UserAgent);
            if (result==null)
            {
                return new AdministratorOTPValidationResult(false,0);
            }
            else
            {
                return new AdministratorOTPValidationResult(true, result.Id)
                {
                    FullName = result.FullName(),
                };
            }
         
        }
    }
}
