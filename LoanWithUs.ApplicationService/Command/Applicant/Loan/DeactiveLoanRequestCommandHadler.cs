using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Applicant.Loan
{
    public class DeactiveLoanRequestCommandHadler : IRequestHandler<DeactiveLoanRequest>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantLoanRequestDomainService _applicantDomainService;
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;

        public DeactiveLoanRequestCommandHadler(IApplicantRepository applicantRepository, IApplicantReadRepository applicantReadRepository, IUnitOfWork unitOfWork, IApplicantLoanRequestDomainService applicantDomainService, IApplicantLoanRequestRepository applicantLoanRequestRepository)
        {
            _applicantRepository = applicantRepository;
            _applicantReadRepository = applicantReadRepository;
            _unitOfWork = unitOfWork;
            _applicantDomainService = applicantDomainService;
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
        }

        public async Task<Unit> Handle(DeactiveLoanRequest request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdForLoanRequest(request.ApplicantId);

          var loanRequest=  applicant.DeactiveLoanRequest(_applicantDomainService);

            _applicantLoanRequestRepository.Update(loanRequest);

          await  _unitOfWork.CommitAsync();

            return Unit.Value;

        }
    }
}
