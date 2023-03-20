using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Query
{
    public class ValidateUserActivationCodeQueryHandler : IRequestHandler<ValidateUserOtpQuery, ValidateOtpQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public ValidateUserActivationCodeQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidateOtpQueryResult> Handle(ValidateUserOtpQuery request, CancellationToken cancellationToken)
        {
            var mobile = request.MobileNumber.RecheckMobileNumber();
            var result = await _userRepository.CheckUserActivationCode(mobile, request.code, request.UserAgent);
            if (result == null)
            {
                return new ValidateOtpQueryResult(false, null, 0);
            }
            else
            {
                if (result.GetType().Name == "Applicant")
                {
                    return new ValidateOtpQueryResult(true, Common.Enum.LoanRoleNames.Applicant, result.Id);
                }
                else
                {
                    return new ValidateOtpQueryResult(true, Common.Enum.LoanRoleNames.Supporter, result.Id);
                }
            }

        }
    }
}
