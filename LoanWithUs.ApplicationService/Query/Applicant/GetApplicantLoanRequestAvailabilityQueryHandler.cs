using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Domain;
using LoanWithUs.Resources;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetApplicantLoanRequestAvailabilityQueryHandler : IRequestHandler<GetApplicantLoanRequestAvailability, ApplicantLoanRequestAvailability>
    {
        private readonly IApplicantLoanRequestDomainService _applicantDomainService;
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly ISupporterRepository _supporterRepository;
        private readonly IMapper _mapper;

        public GetApplicantLoanRequestAvailabilityQueryHandler(IApplicantLoanRequestDomainService applicantDomainService, IApplicantReadRepository applicantRepository, IMapper mapper, ISupporterRepository supporterRepository)
        {
            _applicantDomainService = applicantDomainService;
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _supporterRepository = supporterRepository;
        }

        public async Task<ApplicantLoanRequestAvailability> Handle(GetApplicantLoanRequestAvailability request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.FindApplicantByIdForLoanRequest(request.ApplicantId);

            var loanRequestAvailibility = new ApplicantLoanRequestAvailability();

            if (applicant.UserConfirmation == null || !applicant.UserConfirmation.TotalConfirmation)
            {
                loanRequestAvailibility.CanRequestALoan = false;
                loanRequestAvailibility.NotAvailableResonType = NotAvailableResonType.NotConfirmedProfile;
                loanRequestAvailibility.Description = Messages.ApplicantLoanRequestWithoutTotalConfirmation;
                return loanRequestAvailibility;
            }

            if ((await _applicantDomainService.HasOpenRequest(applicant)))
            {
                loanRequestAvailibility.CanRequestALoan = false;
                loanRequestAvailibility.NotAvailableResonType = NotAvailableResonType.HasOpenRequest;
                loanRequestAvailibility.Description = Messages.ApplicantLoanRequestWithOpenRequest;
                return loanRequestAvailibility;
            }
            else if ((await _applicantDomainService.HasNotSettelledLoan(applicant)))
            {
                loanRequestAvailibility.CanRequestALoan = false;
                loanRequestAvailibility.NotAvailableResonType = NotAvailableResonType.HasNotSettelledLoan;
                loanRequestAvailibility.Description = Messages.ApplicantLoanRequestWithOpenLoan;
                return loanRequestAvailibility;
            }
            else
            {
                loanRequestAvailibility.CanRequestALoan = true;
                var supporter = await _supporterRepository.GetSupporterByIdWithCreditInclude(applicant.SupporterId);
                if (supporter.GetAvailableCredit() < applicant.CurrentLoanLadderFrame.Amount)
                {
                    loanRequestAvailibility.Description = string.Format(Messages.ApplicantLadderInsufficientSupporterCredit, applicant.CurrentLoanLadderFrame.Title);

                    loanRequestAvailibility.ApplicantAvailabileLoanDetail = new ApplicantAvailabileLoanDetail
                    {
                        MaxLoanAmount = supporter.GetAvailableCredit().amount,
                        Installments = applicant.CurrentLoanLadderFrame.AvalableInstallments.Select(m => m.Count).ToArray()
                    };
                }
                else
                {
                    loanRequestAvailibility.ApplicantAvailabileLoanDetail = new ApplicantAvailabileLoanDetail
                    {
                        MaxLoanAmount = applicant.CurrentLoanLadderFrame.Amount.amount,
                        Installments = applicant.CurrentLoanLadderFrame.AvalableInstallments.Select(m => m.Count).ToArray()
                    };
                }
                return loanRequestAvailibility;
            }

        }
    }
}
