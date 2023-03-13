using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Supporter
{
    public class SupporterRegistereApplicantCommandHandler : IRequestHandler<SupporterRegistereApplicantCommand, SupporterRegistereApplicantCammandResult>
    {
        private readonly ISupporterRepository _supporterRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;

        public SupporterRegistereApplicantCommandHandler(ISupporterRepository supporterRepository, IUnitOfWork unitOfWork, IApplicantDomainService applicantDomainService, IApplicantRepository applicantRepository)
        {
            _supporterRepository = supporterRepository;
            _unitOfWork = unitOfWork;
            _applicantDomainService = applicantDomainService;
            _applicantRepository = applicantRepository;
        }

        public async Task<SupporterRegistereApplicantCammandResult> Handle(SupporterRegistereApplicantCommand request, CancellationToken cancellationToken)
        {
            var supporter = await _supporterRepository.GetSupporterById(request.SupporterId);
            if (supporter == null)
            {
                throw new NotFoundException("Current supporter Not Found");
            }

            var applicant = supporter.RegisterNewApplicant(request.MobileNumber, request.NationalCode, request.FirstName, request.LastName, _applicantDomainService);
            await _applicantRepository.CreateApplicant(applicant);

            await _unitOfWork.CommitAsync();
            return new SupporterRegistereApplicantCammandResult()
            {
                ApplicantId = applicant.Id
            };

        }
    }
}
