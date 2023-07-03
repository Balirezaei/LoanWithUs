using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantActiveCurrentBanckAccountCommandHadler : IRequestHandler<ApplicantActiveCurrentBanckAccountCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;

        public ApplicantActiveCurrentBanckAccountCommandHadler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantDomainService = applicantDomainService;
        }

        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantActiveCurrentBanckAccountCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludePersonalInformationAndConfirmation(request.ApplicantId);

            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            applicant.ActiveCurrentBanckAccount(request.ShabaNumber);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();


            return new ApplicantCompleteInformationCommandResult() { Message = "عملیات با موفقیت انجام شد." };
        }
    }

}