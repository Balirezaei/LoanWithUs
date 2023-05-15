using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminPayLoanRequestCommandHandler : IRequestHandler<AdminPayLoanRequestCommand, AdminPayLoanRequestResult>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IDateTimeServiceProvider _dateProvider;
        private readonly IFileRepository _fileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdminPayLoanRequestCommandHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IUnitOfWork unitOfWork, IAdministratorRepository administratorRepository, IDateTimeServiceProvider dateProvider, IFileRepository fileRepository, ILoanRepository loanRepository)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _unitOfWork = unitOfWork;
            _administratorRepository = administratorRepository;
            _dateProvider = dateProvider;
            _fileRepository = fileRepository;
            _loanRepository = loanRepository;
        }

        public async Task<AdminPayLoanRequestResult> Handle(AdminPayLoanRequestCommand request, CancellationToken cancellationToken)
        {
            var loanRequest = await _applicantLoanRequestRepository.FindApplicantLoanRequestForAdmin(request.LoanRequestId);

            var receipt = await _fileRepository.Find(request.FileId);

            var admin = await _administratorRepository.FindAdministratorById(request.AdminId);
            var newLoan = admin.PaiedApplicantLoanRequest(loanRequest, receipt, _dateProvider);

            await _loanRepository.RegisterNewLoan(newLoan);

            await _unitOfWork.CommitAsync();

            return new AdminPayLoanRequestResult
            {

            };
        }
    }
}
