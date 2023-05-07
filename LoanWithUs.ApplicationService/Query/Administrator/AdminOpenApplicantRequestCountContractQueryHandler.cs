using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.ApplicationService.Query.Administrator
{
    public class AdminOpenApplicantRequestCountContractQueryHandler : IRequestHandler<AdminOpenApplicantRequestCountContract, TotalGrid>
    {
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;

        public AdminOpenApplicantRequestCountContractQueryHandler(IApplicantLoanRequestRepository applicantLoanRequestRepository)
        {
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
        }

        public async Task<TotalGrid> Handle(AdminOpenApplicantRequestCountContract request, CancellationToken cancellationToken)
        {
            var c = await _applicantLoanRequestRepository.GetAllOpenRequest().CountAsync();
            return new TotalGrid(c);
        }
    }
}
