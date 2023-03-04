using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class RequestNewOTPCodeForUserCommandHandler : IRequestHandler<RequestNewOTPCodeForUserCommand, UserLoginCommandResult>
    {
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RequestNewOTPCodeForUserCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService)
        {
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
        }
        public async Task<UserLoginCommandResult> Handle(RequestNewOTPCodeForUserCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByMobile(request.Mobile);
            if (applicant == null)
            {
                throw new NotFoundException("شماره موبایل نامعتبر!");
            }

            var newLogin = applicant.AddNewLogin(request.UserAgent);
            await _unitOfWork.CommitAsync();

            return new UserLoginCommandResult(applicant.Id, newLogin.Key);
        }
    }
}