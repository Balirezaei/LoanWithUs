using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.UserAggregate;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetApplicantDashboardQueryHandler : IRequestHandler<GetApplicantDashboardQuery, ApplicantDashboard>
    {
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly IMapper _mapper;

        public GetApplicantDashboardQueryHandler(IApplicantReadRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<ApplicantDashboard> Handle(GetApplicantDashboardQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.FindApplicantByIdWithLadderInclude(request.ApplicantId);

            return new ApplicantDashboard
            {
                CurrentLadder = applicant.CurrentLoanLadderFrame.Step
            };

        }
    }
}
