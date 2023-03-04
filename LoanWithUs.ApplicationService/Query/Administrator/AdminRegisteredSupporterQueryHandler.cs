using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain.UserAggregate;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Administrator
{
    public class AdminRegisteredSupporterQueryHandler : IRequestHandler<AdminRegisteredSupporterContract, List<AdminRegisteredSupporterDto>>
    {
        private readonly ISupporterRepository _supporterRepository;
        private readonly IMapper _mapper;
        
        public AdminRegisteredSupporterQueryHandler(ISupporterRepository supporterRepository, IMapper mapper)
        {
            _supporterRepository = supporterRepository;
            _mapper = mapper;
        }

        public async Task<List<AdminRegisteredSupporterDto>> Handle(AdminRegisteredSupporterContract request, CancellationToken cancellationToken)
        {
            var supporters = await _supporterRepository.GetAllSupporter().DoCommonPagin(request);
            return _mapper.Map<List<AdminRegisteredSupporterDto>>(supporters);
        }
    }
}
