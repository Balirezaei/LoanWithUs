using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class RequestNewOTPCodeForUserCommandHandler : IRequestHandler<RequestNewOTPCodeForUserCommand, UserLoginCommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeServiceProvider _dateProvider;
        public RequestNewOTPCodeForUserCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IApplicantDomainService applicantDomainService, IDateTimeServiceProvider dateProvider)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dateProvider = dateProvider;
        }
        public async Task<UserLoginCommandResult> Handle(RequestNewOTPCodeForUserCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _userRepository.FindUserByMobile(request.MobileNumber);
            if (applicant == null)
            {
                throw new NotFoundException("شماره موبایل نامعتبر!");
            }

            var newLogin = applicant.AddNewLogin(request.UserAgent,_dateProvider);
            await _unitOfWork.CommitAsync();

            return new UserLoginCommandResult(applicant.Id, newLogin.Key);
        }
    }
}