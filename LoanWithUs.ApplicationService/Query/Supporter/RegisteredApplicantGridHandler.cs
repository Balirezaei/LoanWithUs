using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Query.Supporter
{
    public class RegisteredApplicantGridHandler : IRequestHandler<RegisteredApplicantGridContract, List<RegisteredApplicantDto>>
    {
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly ISupporterRepository _supporterRepository;
        private readonly IMapper _mapper;

        public RegisteredApplicantGridHandler(IApplicantReadRepository applicantRepository, ISupporterRepository supporterRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _supporterRepository = supporterRepository;
            _mapper = mapper;
        }

        public async Task<List<RegisteredApplicantDto>> Handle(RegisteredApplicantGridContract request, CancellationToken cancellationToken)
        {
            var query = await _applicantRepository.GetAllApplicantBySupporter(request.SupporterId).DoCommonPagin(request);
            return _mapper.Map<List<RegisteredApplicantDto>>(query);
        }
    }
}
