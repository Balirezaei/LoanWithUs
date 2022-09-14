using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain.UserAggregate;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateApplicantCommand, ApplicantCreatedCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;

        public CreateUserCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantDomainService = applicantDomainService;
        }

        public async Task<ApplicantCreatedCommandResult> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var mobile = request.Mobile.RecheckMobileNumber();
            var savedApplicant =await _applicantReadRepository.FindApplicantByMobile(mobile);
            if (savedApplicant == null)
            {
                var applicant = new Applicant(mobile, _applicantDomainService);
                await _applicantRepository.CreateApplicant(applicant);
            }
            else
            {
                savedApplicant.AddNewLogin();
            }
           
            await _unitOfWork.CommitAsync();
            return new ApplicantCreatedCommandResult();
        }
    }
}