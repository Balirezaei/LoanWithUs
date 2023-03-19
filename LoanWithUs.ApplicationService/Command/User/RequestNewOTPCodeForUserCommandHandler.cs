using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class RequestNewOTPCodeForUserCommandHandler : IRequestHandler<RequestNewOTPCodeForUserCommand, UserLoginCommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RequestNewOTPCodeForUserCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IApplicantDomainService applicantDomainService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<UserLoginCommandResult> Handle(RequestNewOTPCodeForUserCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _userRepository.FindUserByMobile(request.MobileNumber);
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