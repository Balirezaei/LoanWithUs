using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;
        private readonly IDateTimeServiceProvider _dateProvider;

        public LoginUserCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IApplicantDomainService applicantDomainService, IDateTimeServiceProvider dateProvider)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _applicantDomainService = applicantDomainService;
            _dateProvider = dateProvider;
        }

        public async Task<UserLoginCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var mobile = request.MobileNumber.RecheckMobileNumber();
            var user = await _userRepository.FindUserByMobile(mobile);
            if (user == null)
            {
                // applicant = new Applicant(mobile, _applicantDomainService);
                // await _applicantRepository.CreateApplicant(applicant);
                throw new Exception("شما مجوز ورود به سامانه را ندارید.");
            }
            var loginUser = user.AddNewLogin(request.UserAgent,_dateProvider);
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();
            return new UserLoginCommandResult(user.Id, loginUser.Key);
        }
    }
}