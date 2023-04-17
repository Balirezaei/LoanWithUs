using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Encryption;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminUserRequestNewOTPCodeForUserCommandHandler : IRequestHandler<AdminUserRequestNewOTPCodeForUserCommand, AdminRequestOtpResult>
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdminUserRequestNewOTPCodeForUserCommandHandler(IAdministratorRepository administratorRepository, IUnitOfWork unitOfWork)
        {
            _administratorRepository = administratorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminRequestOtpResult> Handle(AdminUserRequestNewOTPCodeForUserCommand request, CancellationToken cancellationToken)
        {
            var admin = await _administratorRepository.FindAdministratorById(request.AdminId);
            var newAttempdToLogin = admin.AddNewAttempdToLogin(request.UserAgent);
            await _unitOfWork.CommitAsync();

            return new AdminRequestOtpResult(newAttempdToLogin.Key, admin.Id);
        }
    }


}
