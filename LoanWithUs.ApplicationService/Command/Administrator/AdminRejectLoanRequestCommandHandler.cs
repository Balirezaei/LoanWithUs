using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminRejectLoanRequestCommandHandler : IRequestHandler<AdminRejectLoanRequestCommand, AdminRejectLoanRequestResult>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IDateTimeServiceProvider _dateProvider;
        private readonly IUnitOfWork _unitOfWork;

        public AdminRejectLoanRequestCommandHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IUnitOfWork unitOfWork, IAdministratorRepository administratorRepository, IDateTimeServiceProvider dateProvider)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _unitOfWork = unitOfWork;
            _administratorRepository = administratorRepository;
            _dateProvider = dateProvider;
        }

        public async Task<AdminRejectLoanRequestResult> Handle(AdminRejectLoanRequestCommand request, CancellationToken cancellationToken)
        {
            var loanRequest = await _applicantLoanRequestRepository.FindApplicantLoanRequestForAdmin(request.LoanRequestId);
            
            var admin = await _administratorRepository.FindAdministratorById(request.AdminId);
            
            admin.RejectApplicantLoanRequest(loanRequest, request.Reason, _dateProvider);

            await _unitOfWork.CommitAsync();
            
            return new AdminRejectLoanRequestResult { };
        }
    }
}
