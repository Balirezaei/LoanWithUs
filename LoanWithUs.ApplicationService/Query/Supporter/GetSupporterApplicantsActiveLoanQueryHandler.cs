using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.ApplicationService.Query.Supporter
{
    public class GetSupporterApplicantsActiveLoanQueryHandler : IRequestHandler<GetSupporterApplicantsActiveLoan, List<SupporterApplicantsActiveLoanDto>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private readonly IApplicantReadRepository _applicantRepository;

        public GetSupporterApplicantsActiveLoanQueryHandler(ILoanRepository loanRepository, IMapper mapper, IApplicantReadRepository applicantRepository)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            _applicantRepository = applicantRepository;
        }

        public async Task<List<SupporterApplicantsActiveLoanDto>> Handle(GetSupporterApplicantsActiveLoan request, CancellationToken cancellationToken)
        {
            var applicants = await _applicantRepository.GetAllApplicantBySupporter(request.SupporterId).ToListAsync();

            var loans = await _loanRepository.GetActiveLoanGroupOfApplicant(applicants.Select(a => a.Id).ToArray());
            return _mapper.Map<List<SupporterApplicantsActiveLoanDto>>(loans);

        }
    }
}