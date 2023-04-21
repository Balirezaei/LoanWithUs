using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.Domain;
using LoanWithUs.Resources;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Supporter
{
    public class GetApplicantRequestDtoQueryHandler : IRequestHandler<GetApplicantRequestDto, ApplicantLoanRequestDto>
    {
        private readonly IApplicantReadRepository _applicantRepository;
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IMapper _mapper;

        public GetApplicantRequestDtoQueryHandler(IApplicantReadRepository applicantRepository, IApplicantLoanRequestRepository applicantLoanRequestRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _mapper = mapper;
        }

        public async Task<ApplicantLoanRequestDto> Handle(GetApplicantRequestDto request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.FindApplicantByIdIncludePersonalInfo(request.ApplicantId);

            if (applicant.SupporterId != request.SupporterId)
            {
                throw new Exception(Messages.SupporterNotAllowedToViewApplicant);
            }

            var applicantRequest = _applicantLoanRequestRepository.FindApplicantLoanRequest(request.RequestId);

            var dto = _mapper.Map<ApplicantLoanRequestDto>(applicantRequest);
            dto.ApplicantFullName = applicant.DisplayName();
            return dto;
        }
    }
}