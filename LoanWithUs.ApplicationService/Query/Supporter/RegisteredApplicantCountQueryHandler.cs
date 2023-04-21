using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.ApplicationService.Query.Supporter
{
    public class RegisteredApplicantCountQueryHandler : IRequestHandler<RegisteredApplicantCountContract, TotalGrid>
    {
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly ISupporterRepository _supporterRepository;
        private readonly IMapper _mapper;

        public RegisteredApplicantCountQueryHandler(IApplicantReadRepository applicantRepository, ISupporterRepository supporterRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _supporterRepository = supporterRepository;
            _mapper = mapper;
        }

        public async Task<TotalGrid> Handle(RegisteredApplicantCountContract request, CancellationToken cancellationToken)
        {
            var c = await _applicantRepository.GetAllApplicantBySupporter(request.SupporterId).CountAsync();
            return new TotalGrid(c);
        }
    }

    
}
