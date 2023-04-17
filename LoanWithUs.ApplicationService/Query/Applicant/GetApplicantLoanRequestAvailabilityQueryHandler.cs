using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Domain;
using LoanWithUs.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetApplicantLoanRequestAvailabilityQueryHandler : IRequestHandler<GetApplicantLoanRequestAvailability, ApplicantLoanRequestAvailability>
    {
        private readonly IApplicantLoanRequestDomainService _applicantDomainService;
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly IMapper _mapper;

        public GetApplicantLoanRequestAvailabilityQueryHandler(IApplicantLoanRequestDomainService applicantDomainService, IApplicantReadRepository applicantRepository, IMapper mapper)
        {
            _applicantDomainService = applicantDomainService;
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<ApplicantLoanRequestAvailability> Handle(GetApplicantLoanRequestAvailability request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.FindApplicantByIdForLoanRequest(request.ApplicantId);

            var loanRequestAvailibility = new ApplicantLoanRequestAvailability();

            if ((await _applicantDomainService.HasOpenRequest(applicant)))
            {
                loanRequestAvailibility.CanRequestALoan = false;
                loanRequestAvailibility.Description = Messages.ApplicantLoanRequestWithOpenRequest;
                return loanRequestAvailibility;
            }
            else if ((await _applicantDomainService.HasNotSettelledLoan(applicant))) {
                loanRequestAvailibility.CanRequestALoan = false;
                loanRequestAvailibility.Description = Messages.ApplicantLoanRequestWithOpenLoan;
                return loanRequestAvailibility;
            }
            else
            {
                loanRequestAvailibility.CanRequestALoan = true;
                loanRequestAvailibility.ApplicantAvailabileLoanDetail = new ApplicantAvailabileLoanDetail
                {
                    MaxLoanAmount = applicant.CurrentLoanLadderFrame.Amount.amount
                };
                return loanRequestAvailibility;
            }

        }
    }
}
