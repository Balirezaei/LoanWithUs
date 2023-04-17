using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetApplicantByIdQueryHandler : IRequestHandler<GetApplicantByIdQuery, ApplicantDto>
    {
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly IMapper _mapper;

        public GetApplicantByIdQueryHandler(IApplicantReadRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<ApplicantDto> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.FindFullApplicantAggregateById(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");
            return _mapper.Map<ApplicantDto>(applicant);
        }
    }
}
