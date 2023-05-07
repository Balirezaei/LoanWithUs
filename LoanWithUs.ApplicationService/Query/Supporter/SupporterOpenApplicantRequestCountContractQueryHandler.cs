using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.ApplicationService.Query.Supporter
{
    public class SupporterOpenApplicantRequestCountContractQueryHandler : IRequestHandler<SupporterOpenApplicantRequestCountContract, TotalGrid>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IMapper _mapper;

        public SupporterOpenApplicantRequestCountContractQueryHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository, IMapper mapper)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _mapper = mapper;
        }

        public async Task<TotalGrid> Handle(SupporterOpenApplicantRequestCountContract request, CancellationToken cancellationToken)
        {
            var c = await _applicantLoanRequestRepository.GetAllOpenLoanRequestOfSupporter(request.SupporterId).CountAsync();
            return new TotalGrid(c);
        }
    }
    
}