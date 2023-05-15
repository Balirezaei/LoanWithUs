using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetApplicantDashboardQueryHandler : IRequestHandler<GetApplicantDashboardQuery, ApplicantDashboard>
    {
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetApplicantDashboardQueryHandler(IApplicantReadRepository applicantRepository, IMapper mapper, ILoanRepository loanRepository)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _loanRepository = loanRepository;
        }

        public async Task<ApplicantDashboard> Handle(GetApplicantDashboardQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.FindApplicantByIdWithLadderInclude(request.ApplicantId);
            var activeLoan = _loanRepository.GetActiveLoan(applicant.Id);
            var result = new ApplicantDashboard
            {
                CurrentLadder = applicant.CurrentLoanLadderFrame.Step
            };

            result.ActiveLoan = (activeLoan != null);

            return result;
        }
    }
}