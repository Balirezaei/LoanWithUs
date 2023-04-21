using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Supporter
{
    public class SupporterOpenApplicantRequestGridContractQueryHandler : IRequestHandler<SupporterOpenApplicantRequestGridContract, List<ApplicantRequestGrid>>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IMapper _mapper;

        public SupporterOpenApplicantRequestGridContractQueryHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IMapper mapper)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<ApplicantRequestGrid>> Handle(SupporterOpenApplicantRequestGridContract request, CancellationToken cancellationToken)
        {
            var list =await _applicantLoanRequestRepository.GetAllOpenRequestOfSupporter(request.SupporterId).DoCommonPagin(request);
            return _mapper.Map<List<ApplicantRequestGrid>>(list);

        }
    }
    
}