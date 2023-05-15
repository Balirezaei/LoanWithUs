using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminConfirmLoanRequestCommandHandler : IRequestHandler<AdminConfirmLoanRequestCommand, AdminRejectLoanRequestResult>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IDateTimeServiceProvider _dateProvider;
        private readonly IUnitOfWork _unitOfWork;

        public AdminConfirmLoanRequestCommandHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IUnitOfWork unitOfWork, IAdministratorRepository administratorRepository, IDateTimeServiceProvider dateProvider)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _unitOfWork = unitOfWork;
            _administratorRepository = administratorRepository;
            _dateProvider = dateProvider;
        }

        public async Task<AdminRejectLoanRequestResult> Handle(AdminConfirmLoanRequestCommand request, CancellationToken cancellationToken)
        {
            var loanRequest = await _applicantLoanRequestRepository.FindApplicantLoanRequestForAdmin(request.LoanRequestId);
            var admin = await _administratorRepository.FindAdministratorById(request.AdminId);
            admin.ConfirmApplicantLoanRequest(loanRequest, _dateProvider);
            await _unitOfWork.CommitAsync();
            return new AdminRejectLoanRequestResult { };
        }
    }
}
