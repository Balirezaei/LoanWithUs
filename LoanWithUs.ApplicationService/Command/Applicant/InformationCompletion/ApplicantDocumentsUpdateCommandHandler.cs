using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantDocumentsUpdateCommandHandler : IRequestHandler<ApplicantDocumentsUpdateCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;
        private readonly IFileRepository _fileRepository;

        public ApplicantDocumentsUpdateCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService, IFileRepository fileRepository)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantDomainService = applicantDomainService;
            _fileRepository = fileRepository;
        }
        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantDocumentsUpdateCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeDocumentsConfirmation(request.ApplicantId);

            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");
            
            var files= request.FileId
                                .Select(m =>
                                        {
                                            return  _fileRepository.Find(m);
                                        })
                                .Select(m=>m.Result)
                                .ToList();

            applicant.UpdateApplicantDucuments(files);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();


            return new ApplicantCompleteInformationCommandResult() { Message = "عملیات با موفقیت انجام شد." };
        }
    }

}