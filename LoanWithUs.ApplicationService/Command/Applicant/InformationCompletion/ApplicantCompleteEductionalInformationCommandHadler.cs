using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantCompleteEductionalInformationCommandHadler : IRequestHandler<ApplicantCompleteEductionalInformationCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;

        public ApplicantCompleteEductionalInformationCommandHadler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantDomainService = applicantDomainService;
        }
        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantCompleteEductionalInformationCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeEducationalInformation(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            applicant.UpdateEducationalInformation(request.LastEducationLevel,request.EducationalSubject);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();

            return new ApplicantCompleteInformationCommandResult() { Message="عملیات با موفقیت انجام شد."};
        }
    }
    
}