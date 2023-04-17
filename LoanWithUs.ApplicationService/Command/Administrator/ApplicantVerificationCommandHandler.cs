using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class ApplicantVerificationCommandHandler : IRequestHandler<ApplicantVerificationCommand, ApplicantVerificationCommandResult>
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantVerificationCommandHandler(IAdministratorRepository administratorRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantRepository applicantRepository)
        {
            _administratorRepository = administratorRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantRepository = applicantRepository;
        }

        public async Task<ApplicantVerificationCommandResult> Handle(ApplicantVerificationCommand request, CancellationToken cancellationToken)
        {
            var applicant =await _applicantReadRepository.FindApplicantById(request.ApplicantId);
            var admin =await _administratorRepository.FindAdministratorById(request.AdminId);
            applicant= admin.ConfirmApplicant(applicant);
            _applicantRepository.Update(applicant);

            await _unitOfWork.CommitAsync();
            return new ApplicantVerificationCommandResult();
        }
    }
}
