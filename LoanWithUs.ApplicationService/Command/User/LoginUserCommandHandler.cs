using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain.UserAggregate;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;

        public LoginUserCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantDomainService = applicantDomainService;
        }

        public async Task<UserLoginCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var mobile = request.MobileNumber.RecheckMobileNumber();
            var applicant = await _applicantReadRepository.FindApplicantByMobile(mobile);
            if (applicant == null)
            {
                // applicant = new Applicant(mobile, _applicantDomainService);
                // await _applicantRepository.CreateApplicant(applicant);
                throw new Exception("شما مجوز ورود به سامانه را ندارید.");
            }
            var loginUser = applicant.AddNewLogin(request.UserAgent);

            await _unitOfWork.CommitAsync();
            return new UserLoginCommandResult(applicant.Id, loginUser.Key);
        }
    }
}