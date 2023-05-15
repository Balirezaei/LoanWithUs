using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetCurrentApplicantLoanRequestDetailQueryHandler : IRequestHandler<GetCurrentApplicantLoanRequestDetail, CurrentApplicantLoanRequestDetail>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IMapper _mapper;

        public GetCurrentApplicantLoanRequestDetailQueryHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IMapper mapper)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _mapper = mapper;
        }

        public async Task<CurrentApplicantLoanRequestDetail> Handle(GetCurrentApplicantLoanRequestDetail request, CancellationToken cancellationToken)
        {
            var loanRequest = await _applicantLoanRequestRepository.FindActiveApplicantLoanRequest(request.ApplicantId);
            if (loanRequest == null)
            {
                return null;
            }
            return _mapper.Map<CurrentApplicantLoanRequestDetail>(loanRequest);

        }
    }
}
