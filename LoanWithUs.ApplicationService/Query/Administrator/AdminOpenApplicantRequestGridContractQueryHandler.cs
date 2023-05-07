using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Administrator
{
    public class AdminOpenApplicantRequestGridContractQueryHandler : IRequestHandler<AdminOpenApplicantRequestGridContract, List<AdminApplicantRequestGrid>>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IMapper _mapper;

        public AdminOpenApplicantRequestGridContractQueryHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IMapper mapper)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<AdminApplicantRequestGrid>> Handle(AdminOpenApplicantRequestGridContract request, CancellationToken cancellationToken)
        {
            var list = await _applicantLoanRequestRepository.GetAllOpenRequest().DoCommonPagin(request);
            return _mapper.Map<List<AdminApplicantRequestGrid>>(list);

        }
    }
}
