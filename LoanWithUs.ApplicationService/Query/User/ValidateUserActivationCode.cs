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
    public class ValidateUserActivationCodeQueryHandler : IRequestHandler<ValidateUserActivationCodeQuery, ValidateUserActivationCodeQueryResult>
    {
        private readonly IApplicantReadRepository _applicantRepository;

        public ValidateUserActivationCodeQueryHandler(IApplicantReadRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<ValidateUserActivationCodeQueryResult> Handle(ValidateUserActivationCodeQuery request, CancellationToken cancellationToken)
        {
            var mobile = request.Mobile.RecheckMobileNumber();
            var result = await _applicantRepository.CheckUserActivationCode(mobile, request.code);
            return new ValidateUserActivationCodeQueryResult(result);
        }
    }
}
