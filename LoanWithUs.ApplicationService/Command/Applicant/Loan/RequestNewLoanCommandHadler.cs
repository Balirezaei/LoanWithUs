using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Applicant.Loan
{
    public class ApplicantRequestLoanCommandHadler : IRequestHandler<ApplicantRequestLoanCommand, ApplicantRequestLoanResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantLoanRequestDomainService _applicantDomainService;
        private readonly IDateTimeServiceProvider _dateProvider;

        public ApplicantRequestLoanCommandHadler(IApplicantRepository applicantRepository, IApplicantReadRepository applicantReadRepository, IUnitOfWork unitOfWork, IApplicantLoanRequestDomainService applicantDomainService, IDateTimeServiceProvider dateProvider)
        {
            _applicantRepository = applicantRepository;
            _applicantReadRepository = applicantReadRepository;
            _unitOfWork = unitOfWork;
            _applicantDomainService = applicantDomainService;
            _dateProvider = dateProvider;
        }

        public async Task<ApplicantRequestLoanResult> Handle(ApplicantRequestLoanCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdForLoanRequest(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            var loanRequest = applicant.RequestNewLoan(request.Reason, request.Amount, new LoanLadderInstallmentsCount(request.LoanLadderInstallmentsCount), _applicantDomainService,_dateProvider);

            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();

            //ToDo:Sens an SMS
            return new ApplicantRequestLoanResult
            {
                State = loanRequest.LastState,
                TrackingNumber = loanRequest.TrackingNumber
            };



        }
    }
}
